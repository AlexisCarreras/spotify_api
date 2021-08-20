using System;
using System.Linq;
using AutoMapper;
using Spotify.Core.Models.Track;
using Spotify.Core.Response;

namespace Spotify.Business.Mapper
{
    public class TrackConfigProfile : Profile
    {
        public TrackConfigProfile()
        {
            CreateMap<TrackModel, Track>()
                .ForMember(dest => dest.artistName, act => act.MapFrom(src => string.Join(", ", src.artists.Select(a => a.name))))
                .ForMember(dest => dest.albumName, act => act.MapFrom(src => src.album.name))
                .ForMember(dest => dest.image, act => act.MapFrom(src => src.album.images.Length == 0 ? "" : src.album.images[0].url))
                .ForMember(dest => dest.trackLength, act => act.MapFrom(src => TrackLenghtFormater.LenghtFormater(src.duration_ms)))
                .ForMember(dest => dest.previewUrl, act => act.MapFrom(src => src.preview_url));
        }
    }
}