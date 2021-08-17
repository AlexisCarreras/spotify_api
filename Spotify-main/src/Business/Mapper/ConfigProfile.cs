using System;
using System.Linq;
using AutoMapper;
using Spotify.Core.Models.Artist;
using Spotify.Core.Response;

namespace Spotify.Business.Mapper
{
    public class ConfigProfile : Profile
    {
        public ConfigProfile()
        {
            CreateMap<AlbumArtist.ItemAlbumArtist, ArtistAlbum>()
                .ForMember(dest => dest.totalTracks, act => act.MapFrom(src => src.total_tracks))
                .ForMember(dest => dest.albumArtist, 
                           act => act.MapFrom(src => ValidLengthArtist(src)))
                .ForMember(dest => dest.image, act => act.MapFrom(src => src.images.Length == 0 ? "" : src.images[0].url));

        }

        private Func<AlbumArtist.ItemAlbumArtist, string> ValidLengthArtist =
            src => src.artists.Length == 0 ? "No Artist" : string.Join(", ", src.artists.Select(a => a.name));

        //private string Valid(AlbumArtist.ItemAlbumArtist src)
        //{
        //    return src.artists.Length == 0 ? "No Artist" : string.Join(", ", src.artists.Select(a => a.name));
        //}
    }
}
