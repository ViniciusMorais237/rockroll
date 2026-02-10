using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Domain.Entities;
using backend.Domain.Entities.DTOs.Commands;
using backend.Domain.Entities.DTOs.Queries;
using backend.Domain.Entities.Infrastructure;
using backend.Domain.Interfaces.Repositories;
using backend.Infrastructure.Mapping;

namespace backend.Infrastructure.Repositories
{
    public class PlaylistRepository : IPlaylistRepository
    {
        private readonly RollDBContext _context;

        public PlaylistRepository(RollDBContext context)
        {
            _context = context;
        }

        public async Task<int> CriarPlaylist(Playlist playlist)
        {
            var playlistDb = new PlaylistDB() { IdUsuario = playlist.IdUsuario, Titulo = playlist.Titulo, Imagem = playlist.Imagem };

            _context.Playlist.Add(playlistDb);

            await _context.SaveChangesAsync();

            return playlistDb.Id;

        }

        public async Task<bool> InserirMusicaPlaylist(int idMusica, int idPlaylist)
        {
            var musicaPlaylist = new MusicaPlaylistDB() { IdMusica = idMusica, IdPlaylist = idPlaylist };
            _context.MusicaPlaylist.Add(musicaPlaylist);

            return await _context.SaveChangesAsync() > 0;
        }
    }
}