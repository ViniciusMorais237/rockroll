using backend.Domain.Entities;
using backend.Domain.Entities.DTOs.Commands;
using backend.Domain.Entities.DTOs.Queries;

namespace backend.Domain.Interfaces.Services
{
    public interface IRollService
    {
        Task<Musica?> ObterInfoMusicaPorId(int id);
        Task<IEnumerable<MusicaResponse>> ObterInfoMusicas(string origem, int id);
        Task<int> InserirMusica(CriarMusicaCommand command);
        Task<bool> DeletarMusica(int id);
    }
}