using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Spotify.Domain.Album.Repository;
using Spotify.Domain.User.Repository;
using Spotify.Repository.Context;
using Spotify.Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Spotify.Repository
{
    public static class ConfigurationModule
    {
        public static IServiceCollection RegisterRepository(this IServiceCollection services, string connectionString)
        {

            services.AddDbContext<SpotifyContext>(c =>
            {
                c.UseSqlServer(connectionString);
            });

            services.AddScoped<IAlbumRepository, AlbumRepository>();
            services.AddScoped<IUserRepository, UserRepository>();

            return services;

        }
    }
}
