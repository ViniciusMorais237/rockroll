using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Domain.Entities;
using backend.Domain.Entities.Infrastructure;
using backend.Domain.Interfaces.Repositories;
using backend.Infrastructure.Mapping;
using Microsoft.EntityFrameworkCore;

namespace backend.Infrastructure.Repositories
{
    public class ArtistasRepository : IArtistasRepository
    {
        private readonly RollDBContext _context;

        public ArtistasRepository(RollDBContext context)
        {
            _context = context;
        }

        public async Task<bool> AdicionarArtista(Artista artista)
        {
            _context.Artistas.Add(new ArtistaDB
            {
                Nome = artista.Nome,
                IdUsuario = 1,
                Premium = artista.Premium,
                UrlFoto = artista.UrlFoto
            });

            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> FollowArtista(int idArtista, int idUsuario)
        {
            var follow = new ArtistaFollowDB()
            {
                IdArtista = idArtista,
                IdUsuario = idUsuario
            };

            _context.Follow.Add(follow);

            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<ArtistaDB?> ObterArtistaPorId(int id)
        {
            return await _context.Artistas.AsNoTracking().FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<IEnumerable<Artista>> ObterArtistasPorPesquisa(string pesquisa)
        {
            var artistas = await _context.Artistas.AsNoTracking().Where(a => a.Nome.StartsWith(pesquisa)).ToListAsync();
            return artistas.Select(a => Artista.Criar(a.Id, a.Nome, false, ""));
        }
    }
}