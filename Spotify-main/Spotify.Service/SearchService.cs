﻿using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using Spotify.Domain.Models;
using Spotify.Domain.Enums;
using Spotify.Domain.Abstract;

namespace Spotify.Service
{
    public class SearchService //: ISearchService
    {
        private readonly HttpClient _httpClient;
        public SearchService()
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri("https://api.spotify.com")
            };
        }

        public Search Search(string name, string type)
        {
            try
            {
                string bearer = "BQAwM-uu-oTHtnb-kDlRd-QiQK5rXfwshWIxs7E3lx7N-9sJnVfz_5cCBEokXGpDq7q3r2oIA3LpvDwtzgo9h_RxwuDLh_8RTTOi-gpijg9xRrvBf1xaWvah2NUjkv0Shu6KT4keFmXTc2w";
                string uri = $"/v1/search?query={name}&type={type.ToLower()}";

                _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/x-www-form-urlencoded"));
                _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {bearer}");

                var result = _httpClient.GetAsync(uri).Result;

                result.EnsureSuccessStatusCode(); // si no es un 200...

                var status = (int)result.StatusCode;

                var responseJson = result.Content.ReadAsStringAsync().Result;

                // Deserializar ArtistSearch


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