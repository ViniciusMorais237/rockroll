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
using Microsoft.EntityFrameworkCore;

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

        public async Task<IEnumerable<Musica?>?> ObterMusicasPlaylist(int id)
        {
            var idsMusicas = await _context.MusicaPlaylist
                .AsNoTracking()
                .Where(m => m.IdPlaylist == id)
                .Select(m => m.IdMusica).ToListAsync();

            if (idsMusicas == null) return null;

            var musicasDb = await _context.Musicas
                .AsNoTracking()
                .Where(m => idsMusicas.Contains(m.Id))
                .ToListAsync();

            return musicasDb.Select(m => Musica.Restaurar(m.Id, m.Titulo, m.IdArtista, m.UrlMusica));
        }

        public async Task<Playlist?> ObterPlaylistPorId(int id)
        {
            var playlistDb = await _context.Playlist.AsNoTracking().FirstOrDefaultAsync(p => p.Id == id);

            if (playlistDb == null) return null;

            return Playlist.Criar(playlistDb.IdUsuario, playlistDb.Titulo, playlistDb.Imagem, null);
        }

        public async Task<IEnumerable<Playlist>?> ObterPlaylistsPorIdUsuario(int idUsuario)
        {
            var listaPlaylistDB = await _context.Playlist.AsNoTracking().Where(p => p.IdUsuario == idUsuario).ToListAsync();

            if (listaPlaylistDB == null) return null;

            return listaPlaylistDB.Select(p => Playlist.Recriar(p.Id, p.IdUsuario, p.Titulo, p.Imagem));
        }
    }
}