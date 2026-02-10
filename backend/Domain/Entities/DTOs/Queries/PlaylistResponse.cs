using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Domain.Entities.DTOs.Queries
{
    public class PlaylistResponse
    {
        public int Id { get; set; }
        public int IdUsuario { get; set; }
        public string? Titulo { get; set; } = string.Empty;
        public string? Imagem { get; set; } = string.Empty;
        public IEnumerable<Musica>? Musicas { get; set; }
    }
}