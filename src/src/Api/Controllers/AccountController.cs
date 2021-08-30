using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Featurify.Core.Entities;
using Featurify.Core.Enums;
using Featurify.Core.Models.Auth;
using Featurify.Core.Request;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace WebApiPaises.Controllers
{
    [Produces("application/json")]
    [Route("api/v1/account")]
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly AuthenticationOptions _authenticationOptions;

        public AccountController(UserManager<ApplicationUser> userManager,
                                 SignInManager<ApplicationUser> signInManager,
                                 IOptions<AuthenticationOptions> options)
        {
            _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
            _signInManager = signInManager;
            _authenticationOptions = options.Value;
        }

        [Route("register")]
        [HttpPost]
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme,
        //           Roles = nameof(RoleEnum.Basic))]
        public async Task<IActionResult> CreateUser([FromBody] UserRegisterRequest model)
        {
            var user = new ApplicationUser
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                UserName = model.UserName,
            };

            var result = await _userManager.CreateAsync(user, model.Password);
            await _userManager.AddToRoleAsync(user, RoleEnum.Admin.ToString());

            return result.Succeeded
                ? Ok(new { Message = $"{model.UserName} Registered." })
                : BadRequest("Username or password invalid");
        }

        [HttpPost]
        [Route("authenticate")]
        public async Task<IActionResult> Login([FromBody] UserAuthenticateRequest userInfo)
        {
            var result = await _signInManager.PasswordSignInAsync(userInfo.UserName, userInfo.Password, isPersistent: false, lockoutOnFailure: false);
            if (result.Succeeded)
            {
                AuthenticationAccess token = await BuildToken(userInfo);

                return Ok(token);
            }

            ModelState.AddModelError(string.Empty, "Invalid login attempt.");
            return BadRequest(ModelState);
        }

        private async Task<AuthenticationAccess> BuildToken(UserAuthenticateRequest userInfo)
        {
            ApplicationUser user = await _userManager.FindByNameAsync(userInfo.UserName);
            var roles = await _userManager.GetRolesAsync(user);

            //Header
            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_authenticationOptions.SecretKey));
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);
            var header = new JwtHeader(signingCredentials);

            //Claims
            var rolesClaims = roles.Select(role => new Claim(ClaimTypes.Role, role));
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim("user_id", user.Id),
                new Claim("user_name", user.UserName),
                new Claim("first_name", user.FirstName),
                new Claim("last_name", user.LastName)
            }
            .Union(rolesClaims);

            //Payload
            var payload = new JwtPayload
            (
                issuer: _authenticationOptions.Issuer,
                audience: _authenticationOptions.Audience,
                claims,
                notBefore: DateTime.Now,
                expires: DateTime.UtcNow.AddMinutes(_authenticationOptions.DurationInMinutes)
            );

            var token = new JwtSecurityToken(header, payload);

            return new AuthenticationAccess
            {
                AccessToken = new JwtSecurityTokenHandler().WriteToken(token),
                Succeeded = true,
                Roles = roles
            };
        }
    }
}