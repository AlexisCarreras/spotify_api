using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
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
        public async Task<Search> Search(string name, SearchEnum type, int offset)
        {
            try
            {
                if (type == SearchEnum.Artist)
                {
                    string uri = $"/v1/search?query={name}&type={type.ToQuery()}&offset={offset}&limit=6";
                    var responseJson = Conexion(uri);
                    var responseArtist = JsonSerializer.Deserialize<ArtistSearch>(responseJson);
                    return responseArtist;
                }
                else if (type == SearchEnum.Album)
                {
                    string uri = $"/v1/search?query={name}&type={type.ToQuery()}&offset={offset}&limit=6";
                    var responseJson = Conexion(uri);
                    var responseAlbum = JsonSerializer.Deserialize<AlbumSearch>(responseJson);
                    return responseAlbum;
                }
                else
                {
                    string uri = $"/v1/search?query={name}&type={type.ToQuery()}&offset={offset}&limit=5";
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
        public async Task<ArtistModel> Artist(string id)
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

        public async Task<ArtistTopTracks> TopTracks(string id, string market)
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

        public async Task<AlbumArtist> AlbumsArtist(string id, int offset)
        {
            try
            {
                string uri = $"/v1/artists/{id}/albums?offset={offset}&limit=20&include_groups=album,single,compilation";
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

        public async Task<AlbumModel> Album(string id)
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

        public async Task<AlbumTracksModel> AlbumTracks(string id)
        {
            try
            {
                string uri = $"/v1/albums/{id}/tracks?limit=50";
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

        public async Task<TrackModel> Track(string id)
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

        public async Task<TrackFeaturesModel> TrackFeatures(string id)
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