using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Featurify.Business.Mapper;
using Featurify.Core.Interfaces;
using Featurify.Core.Models.Artist;
using Featurify.Core.Response;

namespace Featurify.Business
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

        public async Task<Artist> artist(string id)
        {
            var responseService = await _artistService.Artist(id);
            return _mapper.Map<Artist>(responseService);
        }

        public async Task<IEnumerable<ArtistTrack>> ArtistTopTracks(string id, string market = "AR")
        {
            var responseService = (await _artistService.TopTracks(id, market)).tracks;
            return _mapper.Map<List<ArtistTrack>>(responseService);
        }
        public async Task<IEnumerable<ArtistAlbum>> ArtistAlbums(string id, int offset)
        {
            var responseService = (await _artistService.AlbumsArtist(id, offset)).items;
            return _mapper.Map<List<ArtistAlbum>>(responseService);
        }
    }
}