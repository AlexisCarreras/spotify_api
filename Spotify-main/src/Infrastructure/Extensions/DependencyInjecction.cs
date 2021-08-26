using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Spotify.Core.Entities;
using Spotify.Core.Helper;
using Spotify.Core.Interfaces;
using Spotify.Core.Models.Auth;
using Spotify.Infrastructure.Data;
using Spotify.Infrastructure.Service;
using System;
using System.Text;

namespace Spotify.Infrastructure.Extensions
{
    public static class DependencyInjecction
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<FeaturifyContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("Featurify")));

            // Configure identity service
            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<FeaturifyContext>();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                     options.TokenValidationParameters = new TokenValidationParameters
                     {
                         ValidateIssuer = true,
                         ValidateAudience = true,
                         ValidateLifetime = true,
                         ValidateIssuerSigningKey = true,
                         ValidIssuer = configuration["Authentication:Issuer"],
                         ValidAudience = configuration["Authentication:Audience"],
                         IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Authentication:SecretKey"])),
                         ClockSkew = TimeSpan.Zero
                     });

            services.AddOptions();

            var sectionSpotify = configuration.GetSection(SpotifyConfigurationOptions.SpotifyConfiguration);
            services.Configure<SpotifyConfigurationOptions>(sectionSpotify);
            
            var sectionAuth = configuration.GetSection(AuthenticationOptions.Authentication);
            services.Configure<AuthenticationOptions>(sectionAuth);

            services.AddHttpClient("SpotifyClient", client =>
            {
                client.BaseAddress = new Uri(configuration["SpotifyConfiguration:Endpoint"]);
                client.DefaultRequestHeaders.Add("Accept", "application/x-www-form-urlencoded");
            });

            services.AddTransient<ISpotifyService, SpotifyService>();

            return services;
        }
    }
}
