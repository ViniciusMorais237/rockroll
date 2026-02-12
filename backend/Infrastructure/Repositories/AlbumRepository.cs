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

        public Task<bool> AdicionarMusicasAlbum(int idAlbum, int idMusica)
        {
            throw new NotImplementedException();
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

        public Task<bool> ExcluirMusicaAlbum(int idAlbum, int idMusica)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ObterAlbumPorId(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ObterAlbuns(string filtro, string nomeCampo)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<AlbumResponse>?> ObterAlbunsPorIdArtista(int idArtista)
        {
            var albuns = await _context.Albuns.Where(a => a.IdArtista == idArtista).ToListAsync();
            if (albuns.Count == 0) return null;

            return albuns.Select(a => new AlbumResponse() { Id = a.Id, Titulo = a.Titulo, Imagem = a.Imagem });
        }
    }
}