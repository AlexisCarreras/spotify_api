using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace Spotify.Core.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        {
            UsersTracks = new HashSet<UserTrackEntity>();
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public virtual ICollection<UserTrackEntity> UsersTracks { get; set; }
    }
}
