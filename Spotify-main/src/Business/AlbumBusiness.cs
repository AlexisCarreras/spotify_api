using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Spotify.Business.Mapper;
using Spotify.Core.Interfaces;
using Spotify.Core.Models.Album;
using Spotify.Core.Response;

namespace Spotify.Business
{
    public class AlbumBusiness : IAlbumBusiness
    {
        private ISpotifyService _albumService { get; set; }
        private IMapper _mapper { get; set; }
        public AlbumBusiness(ISpotifyService albumService, IMapper mapper)
        {
            _albumService = albumService;
            _mapper = mapper;
        }

        public Album Album(string id)
        {
            var responseService = _albumService.Album(id);
            return _mapper.Map<Album>(responseService);
        }

        public List<AlbumTrack> AlbumTracks(string id)
        {
            var responseService = _albumService.AlbumTracks(id).items;
            return _mapper.Map<List<AlbumTrack>>(responseService);
        }
    }
}
