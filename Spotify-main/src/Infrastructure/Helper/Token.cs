using RestSharp;
using Spotify.Core.Enums;
using Spotify.Core.Models.Auth;
using System;
using System.Text;
using System.Text.Json;

namespace Spotify.Infrastructure.Helper
{
    public static class Token 
    {
        public static string GetToken(string ClientId, string ClientSecret)
        {
            string auth = Convert.ToBase64String(Encoding.UTF8.GetBytes(ClientId + ":" + ClientSecret));
            var client = new RestClient("https://accounts.spotify.com/api/token");
            var request = new RestRequest(Method.POST);

            request.AddHeader("Authorization", $"Basic {auth}");
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddParameter("grant_type", "client_credentials");
            string res = client.Execute(request).Content;
			try
			{
				var token = JsonSerializer.Deserialize<TokenModelSpotify>(res);
				return token.Access_token;
			}
			catch (Exception)
			{
				throw;
			}
        }

        public static string ToQuery(this SearchEnum search)
        {
            return search.ToString().ToLower();
        }
    }
}
