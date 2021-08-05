using System.Collections.Generic;
using Microsoft.Extensions.Options;
using Spotify.Business.Mapper;
using Spotify.Core.Interfaces;
using Spotify.Core.Models;
using Spotify.Core.Response;
using Spotify.Infrastructure.Mapper;

namespace Spotify.Business
{
    public class ArtistBusiness : IArtistBusiness
    {
        private readonly DataLog _data;
        private ISpotifyService _artistService { get; set; }
        public ArtistBusiness(ISpotifyService artistService,
                             IOptions<DataLog> options)
        {
            _artistService = artistService;
            _data = options.Value;
        }

        public Artist artist(string id)
        {
            var responseService = _artistService.Artist(id);

            Artist artist = new Artist()
            {
                name = responseService.name,
                id = responseService.id,
                type = responseService.type,
                genres = responseService.genres,
                popularity = responseService.popularity,
                images = ImageMapper.ImageMapping(responseService.images),
                topTracks = TopTracks(id).ToArray(),
                albums = AlbumArtist(id).ToArray(),
            };

            return artist;
        }
        private List<Track> TopTracks(string id, string market = "AR")
        {
            var responseService = _artistService.TopTracks(id, market);
            var arrTracks = responseService.tracks;


            List<Track> listTopTracks = new List<Track>();
            for (int i = 0; i < arrTracks.Length; i++)
            {
                var trackFeatures = _artistService.TrackFeatures(arrTracks[i].id);

                Track track = new Track()
                {
                    albumName = arrTracks[i].album.name,
                    artistName = arrTracks[i].artists[0].name,
                    id = arrTracks[i].id,
                    name = arrTracks[i].name,
                    trackLength = arrTracks[i].duration_ms,
                    previewUrl = arrTracks[i].preview_url,
                    favorite = false
                };
                track.TrackMapping(trackFeatures);
                listTopTracks.Add(track);
            }
            return listTopTracks;
        }

        private List<Album> AlbumArtist(string id)
        {
            var responseService = _artistService.AlbumsArtist(id);
            var arrAlbums = responseService.items;

            List<Album> listAlbums = new List<Album>();
            for (int i = 0; i < arrAlbums.Length; i++)
            {
                //Track[] tracksAlbum = tr.Album(arrAlbums[i].id).tracks;
                Album album = new Album()
                {
                    name = arrAlbums[i].name,
                    albumArtist = arrAlbums[i].artists[0].name,
                    id = arrAlbums[i].id,
                    images = ImageMapper.ImageMapping(arrAlbums[i].images),
                    totalTracks = arrAlbums[i].total_tracks,
                    type = arrAlbums[i].type,
                    //tracks = tracksAlbum

                };
                listAlbums.Add(album);
            }
            return listAlbums;
        }
    }
}
