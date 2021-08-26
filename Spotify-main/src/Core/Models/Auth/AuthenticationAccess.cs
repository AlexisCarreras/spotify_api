using System.Collections.Generic;

namespace Spotify.Core.Models.Auth
{
    public class AuthenticationAccess
    {
        public bool Succeeded { get; set; }
        public string AccessToken { get; set; }
        public IEnumerable<string> Roles { get; set; }
    }
}
