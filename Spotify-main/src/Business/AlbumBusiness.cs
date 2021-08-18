using System;
using System.Collections.Generic;
using System.Linq;
using Spotify.Business.Mapper;
using Spotify.Core.Interfaces;
using Spotify.Core.Models.Album;
using Spotify.Core.Response;

namespace Spotify.Business
{
    public class AlbumBusiness : IAlbumBusiness
    {
        private ISpotifyService _albumService { get; set; }
        public AlbumBusiness(ISpotifyService albumService)
        {
            _albumService = albumService;
        }

        public Album Album(string id)
        {
            var responseService = _albumService.Album(id);

            Album album = new Album()
            {
                id = responseService.id,
                name = responseService.name,
                totalTracks = responseService.total_tracks,
                type = responseService.type,
                tracks = AlbumTracks(id).ToArray(),
                image = responseService.images.Length == 0 ? "" : responseService.images[0].url,
                albumArtist = string.Join(", ", responseService.artists.Select(a => a.name)),
            };
            return album;
        }

        private List<AlbumTrack> AlbumTracks(string id)
        {
            AlbumTracksModel responseService = _albumService.AlbumTracks(id);
            var arrTracks = responseService.items;

            List<AlbumTrack> albumTracks = new List<AlbumTrack>();
            for (int i = 0; i < arrTracks.Length; i++)
            {
                AlbumTrack track = new AlbumTrack()
                {
                    id = arrTracks[i].id,
                    name = arrTracks[i].name,
                    trackLength = TrackLenghtFormater.LenghtFormater(arrTracks[i].duration_ms),
                    previewUrl = arrTracks[i].preview_url,
                    favorite = false,
                    type = arrTracks[i].type,
                };
                albumTracks.Add(track);
            }
            return albumTracks;
        }
    }
}
