using System;
using System.Net.Http;
using System.Text.Json;
using Microsoft.Extensions.Options;
using Spotify.Core.Abstract;
using Spotify.Core.Enums;
using Spotify.Core.Helper;
using Spotify.Core.Interfaces;
using Spotify.Core.Models.Album;
using Spotify.Core.Models.Artist;
using Spotify.Core.Models.Search;
using Spotify.Core.Models.Track;
using Spotify.Infrastructure.Helper;

namespace Spotify.Infrastructure.Service
{
    public class SpotifyService : ISpotifyService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly SpotifyConfiguration _spotifyConfiguration;
        public SpotifyService(IHttpClientFactory httpClientFactory, IOptions<SpotifyConfiguration> opt)
        {
            _httpClientFactory = httpClientFactory ?? throw new ArgumentNullException(nameof(httpClientFactory));
            _spotifyConfiguration = opt.Value ?? throw new ArgumentNullException(nameof(opt.Value));
        }

        private String Conexion(string uri)
        {
            var client = _httpClientFactory.CreateClient("SpotifyClient");

            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {Token.GetToken(_spotifyConfiguration.ClientId, _spotifyConfiguration.ClientSecret)}");

            var result = client.GetAsync(uri).Result;

            result.EnsureSuccessStatusCode();

            var status = (int)result.StatusCode;

            return result.Content.ReadAsStringAsync().Result;

        }
        public Search Search(string name, string type)
        {
            try
            {
                //string uri = $"/v1/search?query={name}&type={type.ToLower()}&limit=7";
                //var responseJson = Conexion(uri);

                if (type.ToLower() == SearchEnum.Artist.ToString().ToLower())
                {
                    string uri = $"/v1/search?query={name}&type={type.ToLower()}&limit=7";
                    var responseJson = Conexion(uri);
                    var responseArtist = JsonSerializer.Deserialize<ArtistSearch>(responseJson);
                    return responseArtist;
                }
                else if (type.ToLower() == SearchEnum.Album.ToString().ToLower())
                {
                    string uri = $"/v1/search?query={name}&type={type.ToLower()}&limit=7";
                    var responseJson = Conexion(uri);
                    var responseAlbum = JsonSerializer.Deserialize<AlbumSearch>(responseJson);
                    return responseAlbum;
                }
                else
                {
                    string uri = $"/v1/search?query={name}&type={type.ToLower()}&limit=5";
                    var responseJson = Conexion(uri);
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
        public ArtistModel Artist(string id)
        {
            try
            {
                string uri = $"/v1/artists/{id}";
                var responseJson = Conexion(uri);
                var responseArtist = JsonSerializer.Deserialize<ArtistModel>(responseJson);
                return responseArtist;
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine("error inesperado:" + ex.Message);
                return null;
            }
        }

        public ArtistTopTracks TopTracks(string id, string market = "AR")
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

        public TrackFeaturesModel TrackFeatures(string id)
        {
            try
            {
                string uri = $"/v1/audio-features/{id}";
                var responseJson = Conexion(uri);
                var responseTrackFeatures = JsonSerializer.Deserialize<TrackFeaturesModel>(responseJson);
                return responseTrackFeatures;
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine("error inesperado:" + ex.Message);
                return null;
            }
        }
    }
}