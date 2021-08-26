using System.Reflection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Featurify.Business.Search;
using Featurify.Core.Interfaces;
using Featurify.Infrastructure.Extensions;

namespace Featurify.Business.Extensions
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