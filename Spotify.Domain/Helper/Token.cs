using System;
using System.Text;
using System.Text.Json;
using RestSharp;
using Spotify.Domain.Models.Auth;

namespace Spotify.Domain.Helper
{
    public static class Token 
    {
        public static string GetToken()
        {
            string ClientID = "732c3f54134b4e6a875b156899fe2bfa";
            string ClientSecret = "53224f31eace44fabc6767c85ce299db";
            string auth = Convert.ToBase64String(Encoding.UTF8.GetBytes(ClientID + ":" + ClientSecret));
            var client = new RestClient("https://accounts.spotify.com/api/token");
            var request = new RestRequest(Method.POST);

            request.AddHeader("Authorization", $"Basic {auth}");
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddParameter("grant_type", "client_credentials");
            var res = client.Execute(request).Content;
            var token = JsonSerializer.Deserialize<TokenModel>(res);
            return token.access_token;
        }
    }
}
