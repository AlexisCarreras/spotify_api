using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Spotify.Application;
using Spotify.Domain.Interfaces;
using Spotify.Service;
using System;

namespace Spotify.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "MyTestService", Version = "v1", });
            });
            services.AddTransient<ISearchBusiness, SearchBusiness>();
            services.AddTransient<ITrackBusiness, TrackBusiness>();
            services.AddTransient<IAlbumBusiness, AlbumBusiness>();
            services.AddTransient<IArtistBusiness, ArtistBusiness>();
            services.AddTransient<ISpotifyService, SpotifyService>();
            services.AddHttpClient("SpotifyClient", client => 
            {
                client.BaseAddress = new Uri("https://api.spotify.com");
                client.DefaultRequestHeaders.Add("Accept", "application/x-www-form-urlencoded");
            }).AddHeaderPropagation(option => option.Headers.Add("Authorization"));

			services.AddHeaderPropagation(option =>
			{
				option.Headers.Add("Authorization");
			});

            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });
            app.UseHeaderPropagation();

            app.UseCors(b => b.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
