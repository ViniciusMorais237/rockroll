using backend.Domain.Entities;
using backend.Domain.Entities.DTOs.Commands;

namespace backend.Domain.Interfaces.Services
{
    public interface IRollService
    {
        Task<Musica> ObterInfoMusicaPorId(int id);
        Task<bool> InserirMusica(CriarMusicaCommand command);
    }
}