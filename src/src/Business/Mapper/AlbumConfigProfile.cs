using System;
using System.Linq;
using AutoMapper;
using Featurify.Core.Models.Album;
using Featurify.Core.Response;

namespace Featurify.Business.Mapper
{
    public class AlbumConfigProfile : Profile
    {
        public AlbumConfigProfile()
        {
            CreateMap<AlbumModel, Album>()
                .ForMember(dest => dest.image, act => act.MapFrom(src => src.images.Length == 0 ? "" : src.images[0].url))
                .ForMember(dest => dest.totalTracks,
                           act => act.MapFrom(src => src.total_tracks))
                .ForMember(dest => dest.albumArtist, act => act.MapFrom(src => string.Join(", ", src.artists.Select(a => a.name))));

            CreateMap<AlbumTracksModel.Item, AlbumTrack>()
                .ForMember(dest => dest.trackLength, act => act.MapFrom(src => TrackLenghtFormater.LenghtFormater(src.duration_ms)))
                .ForMember(dest => dest.previewUrl,
                           act => act.MapFrom(src => src.preview_url));
        }
    }
}