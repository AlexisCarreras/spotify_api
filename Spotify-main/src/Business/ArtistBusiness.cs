using Spotify.Business.Mapper;
using Spotify.Core.Interfaces;
using Spotify.Core.Models.Artist;
using Spotify.Core.Response;
using System.Collections.Generic;
using System.Linq;

namespace Spotify.Business
{
    public class ArtistBusiness : IArtistBusiness
    {
        private ISpotifyService _artistService { get; set; }
        public ArtistBusiness(ISpotifyService artistService)
        {
            _artistService = artistService;
        }

        public Artist artist(string id)
        {
            var responseService = _artistService.Artist(id);

            Artist artist = new Artist()
            {
                name = responseService.name,
                id = responseService.id,
                type = responseService.type,
                popularity = responseService.popularity,
                topTracks = TopTracks(id).ToArray(),
                albums = AlbumArtist(id).ToArray(),
            };
            artist.image = responseService.images.Length == 0 ? "" : responseService.images[0].url;
            return artist;
        }

        private List<ArtistTrack> TopTracks(string id, string market = "AR")
        {
            var responseService = _artistService.TopTracks(id, market);
            var arrTracks = responseService.tracks;

            List<ArtistTrack> listTopTracks = new List<ArtistTrack>();
            for (int i = 0; i < arrTracks.Length; i++)
            {
                ArtistTrack track = new ArtistTrack()
                {
                    albumName = arrTracks[i].album.name,
                    id = arrTracks[i].id,
                    name = arrTracks[i].name,
                    trackLength = TrackLenghtFormater.LenghtFormater(arrTracks[i].duration_ms),
                    previewUrl = arrTracks[i].preview_url,
                    favorite = false,
                    type = arrTracks[i].type
                };
                listTopTracks.Add(track);
            }
            return listTopTracks;
        }

        private List<ArtistAlbum> AlbumArtist(string id)
        {
            var responseService = _artistService.AlbumsArtist(id);
            var arrAlbums = responseService.items;

            List<ArtistAlbum> listAlbums = new List<ArtistAlbum>();
            for (int i = 0; i < arrAlbums.Length; i++)
            {
                ArtistAlbum album = new ArtistAlbum()
                {
                    name = arrAlbums[i].name,
                    id = arrAlbums[i].id,
                    totalTracks = arrAlbums[i].total_tracks,
                    type = arrAlbums[i].type,
                };
                string arts = string.Join(", ", arrAlbums[i].artists.Select(a => a.name));
                album.albumArtist = arrAlbums[i].artists.Length == 0 ? "No Artist" : arts;
                album.image = arrAlbums[i].images.Length == 0 ? "" : arrAlbums[i].images[0].url;
                listAlbums.Add(album);
            }
            return listAlbums;
        }
    }
}