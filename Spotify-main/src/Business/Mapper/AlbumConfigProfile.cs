using System;
using System.Linq;
using AutoMapper;
using Spotify.Core.Models.Album;
using Spotify.Core.Response;

namespace Spotify.Business.Mapper
{
    public class AlbumConfigProfile : Profile
    {
        public AlbumConfigProfile()
        {
            CreateMap<AlbumTracksModel.Item, AlbumTrack>()
                .ForMember(dest => dest.trackLength, act => act.MapFrom(src => TrackLenghtFormater.LenghtFormater(src.duration_ms)))
                .ForMember(dest => dest.previewUrl,
                           act => act.MapFrom(src => src.preview_url));
        }
    }
}