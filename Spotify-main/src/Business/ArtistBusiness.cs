using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Spotify.Business.Mapper;
using Spotify.Core.Interfaces;
using Spotify.Core.Models.Artist;
using Spotify.Core.Response;

namespace Spotify.Business
{
    public class ArtistBusiness : IArtistBusiness
    {
        private ISpotifyService _artistService { get; set; }
        private IMapper _mapper;
        public ArtistBusiness(ISpotifyService artistService, IMapper mapper)
        {
            _artistService = artistService;
            _mapper = mapper;
        }

        public Artist artist(string id)
        {
            var responseService = _artistService.Artist(id);
            return _mapper.Map<Artist>(responseService);
        }

        public List<ArtistTrack> ArtistTopTracks(string id, string market = "AR")
        {
            var responseService = _artistService.TopTracks(id, market).tracks;
            return _mapper.Map<List<ArtistTrack>>(responseService);
        }
        public List<ArtistAlbum> ArtistAlbums(string id, int offset)
        {
            var responseService = _artistService.AlbumsArtist(id, offset).items;
            return _mapper.Map<List<ArtistAlbum>>(responseService);
        }
    }
}