using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Domain.Entities;
using backend.Domain.Entities.DTOs.Queries;
using backend.Domain.Entities.Infrastructure;
using backend.Domain.Interfaces.Repositories;
using backend.Infrastructure.Mapping;
using Microsoft.EntityFrameworkCore;

namespace backend.Infrastructure.Repositories
{
    public class AlbumRepository : IAlbumRepository
    {
        private readonly RollDBContext _context;

        public AlbumRepository(RollDBContext context)
        {
            _context = context;
        }

        public async Task<bool> AdicionarMusicasAlbum(int idAlbum, int idMusica)
        {
            var musica = new MusicaAlbumDB()
            {
                IdAlbum = idAlbum,
                IdMusica = idMusica
            };

            _context.Add(musica);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> AdicionarMusicasAlbum(int idAlbum, IEnumerable<int> idsMusicas)
        {
            var musicas = idsMusicas.Select(id => new MusicaAlbumDB()
            {
                IdAlbum = idAlbum,
                IdMusica = id
            });

            _context.AddRange(musicas);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<int> CriarAlbum(Album album)
        {
            var albumEntity = new AlbumDB()
            {
                Titulo = album.Titulo,
                IdArtista = album.IdArtista,
                Imagem = album.Imagem
            };

            _context.Albuns.Add(albumEntity);

            await _context.SaveChangesAsync();
            return albumEntity.Id;
        }

        public Task<bool> EditarAlbum(Album album)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ExcluirAlbum(int idAlbum)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> ExcluirMusicaAlbum(int idAlbum, int idMusica)
        {
            return await _context.MusicaAlbum
                .Where(A => A.IdAlbum == idAlbum && A.IdMusica == idMusica)
                .ExecuteDeleteAsync() > 0;
        }

        public async Task<AlbumResponse?> ObterAlbumPorId(int id)
        {
            var album = await _context.Albuns.FirstOrDefaultAsync(A => A.Id == id);
            if (album == null) return null;

            var query = from ma in _context.MusicaAlbum.AsNoTracking()
                        join m in _context.Musicas.AsNoTracking()
                        on ma.IdMusica equals m.Id
                        where ma.IdAlbum == id
                        select new { musicaInfo = m, musicaJoin = ma };

            var resultado = await query.ToListAsync();
            var musicas = resultado.Select(r => new MusicaResponse
            {
                Id = r.musicaInfo.Id,
                Titulo = r.musicaInfo.Titulo,
                UrlMusica = r.musicaInfo.UrlMusica,
                UrlImagem = r.musicaInfo.UrlImagem
            });

            return new AlbumResponse { Id = id, Imagem = album.Imagem, Titulo = album.Titulo, Musicas = musicas };
        }

        public Task<bool> ObterAlbuns(string filtro, string nomeCampo)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<AlbumResponseResumido>?> ObterAlbunsPorIdArtista(int idArtista)
        {
            var albuns = await _context.Albuns.Where(a => a.IdArtista == idArtista).ToListAsync();
            if (albuns.Count == 0) return null;

            return albuns.Select(a => new AlbumResponseResumido() { Id = a.Id, Titulo = a.Titulo, Imagem = a.Imagem });
        }
    }
}