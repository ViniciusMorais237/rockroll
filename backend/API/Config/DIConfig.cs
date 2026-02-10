using backend.Domain.Interfaces.Repositories;
using backend.Domain.Interfaces.Services;
using backend.Domain.Services;
using backend.Domain.UseCases.ArtistasCommands;
using backend.Domain.UseCases.ArtistasQueries;
using backend.Domain.UseCases.MusicasQueries;
using backend.Infrastructure.Mapping;
using backend.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace backend.API.Config
{
    public static class DIConfig
    {
        public static IServiceCollection AddDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IRollService, RollService>();
            services.AddScoped<IRollRepository, RollRepository>();

            services.AddScoped<IArtistasService, ArtistasService>();
            services.AddScoped<IArtistasRepository, ArtistasRepository>();

            services.AddScoped<IArquivoService, ArquivoService>();


            //USE CASES
            services.AddScoped<ObterArtistaPorId>();
            services.AddScoped<FollowArtista>();

            //MUSICAS
            services.AddScoped<ObterMusicasPorFiltro>();

            services.AddScoped<IUoW, UoW>();

            services.AddDbContext<RollDBContext>(options =>
            options.UseSqlServer(
                configuration.GetConnectionString("DefaultConnection")
            )
        );

            return services;
        }
    }
}