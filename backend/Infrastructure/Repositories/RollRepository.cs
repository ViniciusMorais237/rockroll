using backend.Domain.Entities;
using backend.Domain.Entities.DTOs.Queries;
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

        public async Task<Musica?> ObterInfoMusicaPorId(int id)
        {
            try
            {
                var musica = await _context.Musicas
                    .AsNoTracking()
                    .FirstOrDefaultAsync(m => m.Id == id);

                if (musica == null) return null;

                return new Musica(
                    musica.Titulo,
                    0,
                    musica.UrlMusica);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<int> InserirMusica(Musica musica)
        {
            try
            {
                var musicaDb = new MusicaDB
                {
                    Titulo = musica.Titulo,
                    IdArtista = musica.IdArtista,
                    UrlMusica = musica.UrlMusica,
                    UrlImagem = musica.UrlImagem,
                };

                _context.Musicas.Add(musicaDb);

                var insert = await _context.SaveChangesAsync();
                return musicaDb.Id;
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

        public async Task<IEnumerable<Musica?>?> ObterInfoMusicasPorArtistaId(int? idArtista)
        {
            if (idArtista == null) return [];

            return await _context.Musicas
                .AsNoTracking()
                .Where(m => m.IdArtista == idArtista)
                .Select(m => Musica.Restaurar(m.Id, m.Titulo, m.UrlMusica))
                .ToListAsync();
        }

        public async Task<IEnumerable<MusicaSelect>?> ObterSelectMusicasPorFiltro(string filtro)
        {
            var musicas = await _context.Musicas
                .AsNoTracking()
                .Where(m => m.Titulo.Contains(filtro))
                .ToListAsync();

            if (musicas == null) return null;

            return musicas.Select(m => new MusicaSelect() { Id = m.Id, Nome = m.Titulo });

        }
    }
}