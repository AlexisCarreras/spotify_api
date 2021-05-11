﻿using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using Spotify.Domain.Models;
using Spotify.Domain.Enums;
using Spotify.Domain.Abstract;
using Spotify.Domain.Response;

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
            string bearer = "BQD2-SY5F64TpneDoUGr9sCPjgoYSOswpggSsJ9_X2pwqIlo5NUbt2vpc26NoiP1uWgyZf5_7ny92iGExj3ekSXx86mRMRMzzNPpkLDh7NeR3uSRjjc5JgFasPyg2hEZTDlBMYmL4t7eQd8";

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

        public ArtistTopTracks TopTracks(string id, string market = "ar")
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