using System;
using System.Linq;
using AutoMapper;
using Featurify.Core.Models.Artist;
using Featurify.Core.Response;

namespace Featurify.Business.Mapper
{
    public class ArtistConfigProfile : Profile
    {
        public ArtistConfigProfile()
        {
            CreateMap<AlbumArtist.ItemAlbumArtist, ArtistAlbum>()
                .ForMember(dest => dest.totalTracks, act => act.MapFrom(src => src.total_tracks))
                .ForMember(dest => dest.albumArtist, 
                           act => act.MapFrom(src => ValidLengthArtist(src)))
                .ForMember(dest => dest.image, act => act.MapFrom(src => src.images.Length == 0 ? "" : src.images[0].url));

            CreateMap<ArtistTopTracks.Track, ArtistTrack>()
                .ForMember(dest => dest.albumName, act => act.MapFrom(src => src.album.name))
                .ForMember(dest => dest.trackLength, act => act.MapFrom(src => TrackLenghtFormater.LenghtFormater(src.duration_ms)))
                .ForMember(dest => dest.previewUrl, act => act.MapFrom(src => src.preview_url));

            CreateMap<ArtistModel, Artist>()
                .ForMember(dest => dest.image, act => act.MapFrom(src => src.images.Length == 0 ? "" : src.images[0].url));
        }
        private Func<AlbumArtist.ItemAlbumArtist, string> ValidLengthArtist =
            src => src.artists.Length == 0 ? "No Artist" : string.Join(", ", src.artists.Select(a => a.name));
    }
}
