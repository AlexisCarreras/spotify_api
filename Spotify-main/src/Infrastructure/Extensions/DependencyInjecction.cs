using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Spotify.Core.Helper;
using Spotify.Core.Interfaces;
using Spotify.Infrastructure.Service;

namespace Spotify.Infrastructure.Extensions
{
    public static class DependencyInjecction
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddOptions();
            var section = configuration.GetSection("SpotifyConfiguration");
            services.Configure<SpotifyConfiguration>(section);
            var url = configuration["SpotifyConfiguration:Endpoint"];

            services.AddHttpClient("SpotifyClient", client =>
            {
                client.BaseAddress = new Uri(configuration["SpotifyConfiguration:Endpoint"]);
                client.DefaultRequestHeaders.Add("Accept", "application/x-www-form-urlencoded");
            });

            services.AddTransient<ISpotifyService, SpotifyService>();

            return services;
        }
    }
}
