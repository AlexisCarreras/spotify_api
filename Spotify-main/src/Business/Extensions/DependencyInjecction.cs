using System.Reflection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Spotify.Core.Interfaces;
using Spotify.Infrastructure.Extensions;

namespace Spotify.Business.Extensions
{
    public static class DependencyInjecction
    {
        public static IServiceCollection AddBusiness(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<ISearchBusiness, SearchBusiness>();
            services.AddTransient<ITrackBusiness, TrackBusiness>();
            services.AddTransient<IAlbumBusiness, AlbumBusiness>();
            services.AddTransient<IArtistBusiness, ArtistBusiness>();

            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddInfrastructure(configuration);

            return services;
        }
    }
}