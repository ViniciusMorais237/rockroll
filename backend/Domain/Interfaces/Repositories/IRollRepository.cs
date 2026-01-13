using backend.Domain.Entities;

namespace backend.Domain.Interfaces.Repositories
{
    public interface IRollRepository
    {
         Task<Musica> ObterMusicaPorId(int id);
    }
}