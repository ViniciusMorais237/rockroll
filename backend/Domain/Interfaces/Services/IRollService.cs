using backend.Domain.Entities;
using backend.Domain.Entities.DTOs;

namespace backend.Domain.Interfaces.Services
{
    public interface IRollService
    {
        Task<Musica> ObterMusicaPorId(int id);
        Task<bool> InserirMusica(CriarMusicaCommand command);
    }
}