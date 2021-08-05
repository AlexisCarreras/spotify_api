using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Spotify.Core.Interfaces;
using Spotify.Infrastructure.Service;

namespace Spotify.Infrastructure.Extensions
{
    public static class DependencyInjecction
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            var url = configuration["SpotifyUrl"];
            services.AddHttpClient("SpotifyClient", client =>
            {
                client.BaseAddress = new Uri(configuration["SpotifyUrl"]);
                client.DefaultRequestHeaders.Add("Accept", "application/x-www-form-urlencoded");
            });

            services.AddTransient<ISpotifyService, SpotifyService>();

            return services;
        }
    }
}
