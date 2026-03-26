using backend.Domain.Interfaces.Repositories;
using backend.Domain.Interfaces.Services;
using backend.Domain.Services;
using backend.Domain.UseCases.AlbunsCommands;
using backend.Domain.UseCases.AlbunsQueries;
using backend.Domain.UseCases.ArtistasCommands;
using backend.Domain.UseCases.ArtistasQueries;
using backend.Domain.UseCases.MusicasQueries;
using backend.Domain.UseCases.PlaylistCommands;
using backend.Domain.UseCases.PlaylistQueries;
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

            services.AddScoped<IUsuarioService, UsuarioService>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();

            services.AddScoped<IArtistasService, ArtistasService>();
            services.AddScoped<IArtistasRepository, ArtistasRepository>();

            services.AddScoped<IPlaylistRepository, PlaylistRepository>();

            services.AddScoped<IAlbumRepository, AlbumRepository>();

            services.AddScoped<IArquivoService, ArquivoService>();

            services.AddScoped<IPasswordService, PasswordService>();


            //USE CASES
            services.AddScoped<ObterArtistaPorId>();

            services.AddScoped<ObterPlaylist>();
            services.AddScoped<ObterPlaylistsPorIdUsuario>();
            services.AddScoped<CriarPlaylist>();
            services.AddScoped<AdicionarMusicaPlaylist>();

            services.AddScoped<FollowArtista>();


            services.AddScoped<ObterAlbunsPorIdArtista>();
            services.AddScoped<CriarAlbum>();
            services.AddScoped<ObterAlbum>();
            services.AddScoped<AdicionarMusicaAlbum>();
            services.AddScoped<ExcluirMusicaAlbum>();

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