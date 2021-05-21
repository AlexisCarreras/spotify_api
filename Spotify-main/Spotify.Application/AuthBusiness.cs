using Spotify.Domain.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace Spotify.Application
{
	public class AuthBusiness
	{
		private Service.SpotifyService _authService { get; set; }
        public AuthBusiness()
        {
            _authService = new Service.SpotifyService();
        }

        public Service.SpotifyService GetAuthService()
        {
            return _authService;
        }

        //public Auth Auth()
        //{
            
        //}
    }
}
