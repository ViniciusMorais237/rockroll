using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Domain.Entities;
using backend.Domain.Entities.Infrastructure;
using backend.Domain.Interfaces.Repositories;
using backend.Infrastructure.Mapping;

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
                Premium = artista.Premium,
                UrlFoto = artista.UrlFoto,
                DtInsercao = DateTime.Now,
                Ativo = 1
            });
            return await _context.SaveChangesAsync() > 0;
        }

        public Task<Artista> ObterArtistaPorId(int id)
        {
            throw new NotImplementedException();
        }
    }
}