using System;
using System.Text;
using System.Text.Json;
using RestSharp;
using Spotify.Core.Enums;
using Spotify.Core.Models.Auth;

namespace Spotify.Infrastructure.Helper
{
    public static class Token 
    {
        public static string GetToken(string ClientId, string ClientSecret)
        {
            string res = "";
            string auth = Convert.ToBase64String(Encoding.UTF8.GetBytes(ClientId + ":" + ClientSecret));
            var client = new RestClient("https://accounts.spotify.com/api/token");
            var request = new RestRequest(Method.POST);

            request.AddHeader("Authorization", $"Basic {auth}");
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddParameter("grant_type", "client_credentials");
			res = client.Execute(request).Content;
			try
			{
				var token = JsonSerializer.Deserialize<TokenModel>(res);
				return token.access_token;
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
