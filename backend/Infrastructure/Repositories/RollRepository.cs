using backend.Domain.Entities;
using backend.Domain.Interfaces.Repositories;

namespace backend.Infrastructure.Repositories
{
    public class RollRepository : IRollRepository
    {
        // private readonly IDBcontext
        private readonly Dictionary<int, Musica> DBMock = new()
        {
            {1, new Musica{Id = 1, IdArtista = 1, NomeArtista = "Jeff msc", Titulo = "Your iza", UrlMusica = "https://youtube.com/watch?v=qUOTbRW0HSw"}}
        };
        public async Task<Musica> ObterMusicaPorId(int id)
        {
            if(DBMock.TryGetValue(id, out var musica))
            {
                return musica;
            }
            throw new Exception($"Não existe nenhuma musica com id {id}");
        }

    }
}