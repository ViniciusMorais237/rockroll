using backend.Domain.Entities;
using backend.Domain.Entities.DTOs.Queries;

namespace backend.Domain.Interfaces.Repositories
{
    public interface IRollRepository
    {
        Task<Musica?> ObterInfoMusicaPorId(int id);

        Task<IEnumerable<Musica>?> ObterInfoMusicasPorIds(IEnumerable<int> ids);
        Task<IEnumerable<MusicaSelect>?> ObterSelectMusicasPorFiltro(string filtro);
        Task<IEnumerable<Musica?>?> ObterInfoMusicasPorArtistaId(int? id);
        Task<IEnumerable<Artista>?> ObterArtistasPorMusicaId(int idMusica);
        Task<int> InserirMusica(Musica musica);
        Task<bool> InserirArtistasMusica(int idMusica, List<Artista> artistas);
    }
}