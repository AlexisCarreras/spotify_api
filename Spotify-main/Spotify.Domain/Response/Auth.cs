using System;
using System.Collections.Generic;
using System.Text;

namespace Spotify.Domain.Response
{
	public class Auth
	{
		public string access_token { get; set; }
		public string token_type { get; set; }
		public string refresh_token { get; set; }
		public string scope { get; set; }

	}
}
