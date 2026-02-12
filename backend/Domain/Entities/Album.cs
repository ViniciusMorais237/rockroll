using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Domain.Interfaces.Repositories;

namespace backend.Domain.Entities
{
    public class Album
    {
        private Album(int idArtista, string? titulo, string? imagem, IEnumerable<int>? musicas)
        {
            IdArtista = idArtista;
            Titulo = titulo;
            Imagem = imagem;
            Musicas = musicas?.ToList();
        }

        public int Id { get; set; }
        public int IdArtista { get; set; }
        public string? Titulo { get; set; } = string.Empty;
        public string? Imagem { get; set; } = string.Empty;
        public IReadOnlyList<int>? Musicas { get; set; }

        public static Album Criar(int idArtista, string? titulo, string? imagem, IEnumerable<int>? musicas)
        {
            return new Album(idArtista, titulo, imagem, musicas);
        }

        public static Album Recriar(int idArtista, string? titulo, string? imagem)
        {
            return new Album(idArtista, titulo, imagem, null);
        }

        public void DefinirId(int id)
        {
            Id = id;
        }

        public async Task PersistirMusicas(IAlbumRepository repository)
        {
            if(Musicas == null) return;

            await repository.AdicionarMusicasAlbum(Id, Musicas);
        }
    }
}