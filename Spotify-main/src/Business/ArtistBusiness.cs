using System.Collections.Generic;
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

        public Artist artist(string id, int offset)
        {
            var responseService = _artistService.Artist(id);

            Artist artist = new Artist()
            {
                name = responseService.name,
                id = responseService.id,
                type = responseService.type,
                popularity = responseService.popularity,
                topTracks = TopTracks(id).ToArray(),
                albums = AlbumArtist(id, offset).ToArray(),
            };

            artist.image = responseService.images.Length == 0 ? "" : responseService.images[0].url;
            return artist;
        }

        private List<ArtistTrack> TopTracks(string id, string market = "AR")
        {
            var responseService = _artistService.TopTracks(id, market);
            if (responseService is null) 
            {
                var responseService2 = _artistService.TopTracks(id, market);
            }
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

        private List<ArtistAlbum> AlbumArtist(string id, int offset)
        {
            AlbumArtist responseService = _artistService.AlbumsArtist(id, offset);

            return _mapper.Map<List<ArtistAlbum>>(responseService.items);
        }
    }
}