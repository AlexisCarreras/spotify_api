using Spotify.Domain.Interfaces;
using Spotify.Domain.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace Spotify.Application
{
	public class AuthBusiness
	{
		private ISpotifyService _authService { get; set; }
        public AuthBusiness(ISpotifyService authService)
        {
            _authService = authService;
        }

        //public Service.SpotifyService GetAuthService()
        //{
        //    return _authService;
        //}

        //public Auth Auth()
        //{
            
        //}
    }
}
