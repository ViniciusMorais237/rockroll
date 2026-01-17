using backend.Domain.Entities;

namespace backend.Domain.Interfaces.Repositories
{
    public interface IRollRepository
    {
         Task<Musica?> ObterInfoMusicaPorId(int id);
         Task<IEnumerable<Artista>?> ObterArtistasPorMusicaId(int idMusica);
         Task<bool> InserirMusica(Musica musica);
         Task<bool> InserirArtistasMusica(int idMusica, List<Artista> artistas);
    }
}