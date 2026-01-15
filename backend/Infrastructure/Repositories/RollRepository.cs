using backend.Domain.Entities;
using backend.Domain.Entities.Infrastructure;
using backend.Domain.Interfaces.Repositories;
using backend.Infrastructure.Mapping;
using Microsoft.EntityFrameworkCore;

namespace backend.Infrastructure.Repositories
{
    public class RollRepository : IRollRepository
    {
        private readonly RollDBContext _context;
        public RollRepository(RollDBContext context)
        {
            _context = context;
        }

        public async Task<Musica?> ObterMusicaPorId(int id)
        {
            try
            {
                var musica = await _context.Musicas
                    .AsNoTracking()
                    .FirstOrDefaultAsync(m => m.Id == id);

                if (musica == null) return null;

                return new Musica(
                    musica.Titulo,
                    musica.UrlMusica,
                    [new(1, "Jeff")]);


            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<bool> InserirMusica(Musica musica)
        {
            try
            {
                await _context.Musicas.AddAsync(new MusicaDB
                {
                    Titulo = musica.Titulo,
                    UrlMusica = musica.UrlMusica,
                    UrlImagem = musica.UrlImagem,
                });

                var insert = await _context.SaveChangesAsync();
                return insert > 0;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> InserirArtistasMusica(int idMusica, List<Artista> artistas)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Artista>?> ObterArtistasPorMusicaId(int idMusica)
        {
            throw new NotImplementedException();
        }

    }
}