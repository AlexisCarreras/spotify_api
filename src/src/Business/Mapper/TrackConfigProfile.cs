using System;
using System.Linq;
using AutoMapper;
using Featurify.Core.Models.Track;
using Featurify.Core.Response;

namespace Featurify.Business.Mapper
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

            string[] keys = { "C", "C#", "D", "D#", "E", "F", "F#", "G", "G#", "A", "A#", "B" };
            string[] mode = { "Menor", "Mayor" };

            CreateMap<TrackFeaturesModel, TrackFeature>()
                .ForMember(dest => dest.acousticness, act => act.MapFrom(src => src.acousticness * 1000))
                .ForMember(dest => dest.danceability, act => act.MapFrom(src => src.danceability * 1000))
                .ForMember(dest => dest.energy, act => act.MapFrom(src => src.energy * 1000))
                .ForMember(dest => dest.instrumentalness, act => act.MapFrom(src => src.instrumentalness * 1000))
                .ForMember(dest => dest.liveness, act => act.MapFrom(src => src.liveness * 1000))
                .ForMember(dest => dest.speechiness, act => act.MapFrom(src => src.speechiness * 1000))
                .ForMember(dest => dest.valence, act => act.MapFrom(src => src.valence * 1000))
                .ForMember(dest => dest.tempo, act => act.MapFrom(src => src.tempo))
                .ForMember(dest => dest.key, act => act.MapFrom(src => keys[src.key]))
                .ForMember(dest => dest.mode, act => act.MapFrom(src => mode[src.mode]));

        }
    }
}