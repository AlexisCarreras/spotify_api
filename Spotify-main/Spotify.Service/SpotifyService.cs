using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using Spotify.Domain.Models;
using Spotify.Domain.Enums;
using Spotify.Domain.Abstract;
using Spotify.Domain.Response;
using static Spotify.Domain.Models.AlbumArtist;

namespace Spotify.Service
{
    public class SpotifyService //: ISearchService
    {
        private readonly HttpClient _httpClient;
        public SpotifyService()
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri("https://api.spotify.com")
            };
        }

        private String Conexion(string uri)
        {
            _httpClient.DefaultRequestHeaders.Clear();
            string bearer = "BQBTBhktN99iDEHTFArTsTyGOneCMcTleclMLNqmWstbzMJnu509S40CPN8_L9OqEFCONUCa9P6CI_Pju9wa0WIEVOc3aUjdpR0D-6CS-bkL0kKwvKCeB1-kQJQA4TQ3-pbl3q5EnrHFeDU";

            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/x-www-form-urlencoded"));
            _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {bearer}");

            var result = _httpClient.GetAsync(uri).Result;

            result.EnsureSuccessStatusCode(); // si no es un 200...

            var status = (int)result.StatusCode;

            return result.Content.ReadAsStringAsync().Result;
        }

        public Search Search(string name, string type)
        {
            try
            {
                string uri = $"/v1/search?query={name}&type={type.ToLower()}";
                var responseJson = Conexion(uri);

                if (type.ToLower() == SearchEnum.Artist.ToString().ToLower())
                {
                    var responseArtist = JsonSerializer.Deserialize<ArtistSearch>(responseJson);
                    return responseArtist;
                }
                else if (type.ToLower() == SearchEnum.Album.ToString().ToLower())
                {
                    var responseAlbum = JsonSerializer.Deserialize<AlbumSearch>(responseJson);
                    return responseAlbum;
                }
                else
                {
                    var responseTrack = JsonSerializer.Deserialize<TrackSearch>(responseJson);
                    return responseTrack;
                }
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine("error inesperado:" + ex.Message);
                return null;
            }
        }

        public ItemArtistSearch Artist(string id)
        {
            try
            {
                string uri = $"/v1/artists/{id}";
                var responseJson = Conexion(uri);
                var responseArtist = JsonSerializer.Deserialize<ItemArtistSearch>(responseJson);
                return responseArtist;
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine("error inesperado:" + ex.Message);
                return null;
            }
        }

        public ArtistTopTracks TopTracks(string id, string market = "from_token")
        {
            try
            {
                string uri = $"/v1/artists/{id}/top-tracks?market={market}";
                var responseJson = Conexion(uri);
                var responseTopTracks = JsonSerializer.Deserialize<ArtistTopTracks>(responseJson);
                return responseTopTracks;
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine("error inesperado:" + ex.Message);
                return null;
            }
        }

		public AlbumArtist AlbumsArtist(string id)
		{
			try
			{
				string uri = $"/v1/artists/{id}/albums";
				var responseJson = Conexion(uri);
				var responseAlbumsArtist = JsonSerializer.Deserialize<AlbumArtist>(responseJson);
				return responseAlbumsArtist;
			}
			catch (HttpRequestException ex)
			{
				Console.WriteLine("error inesperado:" + ex.Message);
				return null;
			}

		}

        public AlbumModel Album(string id)
        {
            try
            {
                string uri = $"/v1/albums/{id}";
                var responseJson = Conexion(uri);
                var responseAlbums = JsonSerializer.Deserialize<AlbumModel>(responseJson);
                return responseAlbums;
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine("error inesperado:" + ex.Message);
                return null;
            }

        }

        public AlbumTracksModel AlbumTracks(string id)
        {
            try
            {
                string uri = $"/v1/albums/{id}/tracks";
                var responseJson = Conexion(uri);
                var responseAlbums = JsonSerializer.Deserialize<AlbumTracksModel>(responseJson);
                return responseAlbums;
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine("error inesperado:" + ex.Message);
                return null;
            }

        }

        public TrackModel Track(string id)
        {
            try
            {
                string uri = $"/v1/tracks/{id}";
                var responseJson = Conexion(uri);
                var responseAlbums = JsonSerializer.Deserialize<TrackModel>(responseJson);
                return responseAlbums;
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine("error inesperado:" + ex.Message);
                return null;
            }

        }

    }
}






//VerifyResponse();
//if (!result.IsSuccessStatusCode)
//{
//    switch (result.StatusCode)
//    {
//        case HttpStatusCode.BadRequest:
//            throw new Exception("BadRequest");
//            break;
//        default:
//            break;
//    } 
//}

//