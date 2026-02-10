using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Domain.Entities
{
    public class Playlist
    {
        private Playlist(int idUsuario, string? titulo, string? imagem, IEnumerable<Musica>? musicas)
        {
            IdUsuario = idUsuario;
            Titulo = titulo;
            Imagem = imagem;
            Musicas = musicas;
        }

        public int Id { get; set; }
        public int IdUsuario { get; set; }
        public string? Titulo { get; set; } = string.Empty;
        public string? Imagem { get; set; } = string.Empty;
        public IEnumerable<Musica>? Musicas { get; set; }

        public static Playlist Criar(int idUsuario, string? titulo, string? imagem, IEnumerable<Musica>? musicas)
        {
            return new Playlist(idUsuario, titulo, imagem, musicas);
        }
    }
}