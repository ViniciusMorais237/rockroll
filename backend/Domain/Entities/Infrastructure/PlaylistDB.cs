using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Domain.Entities.Infrastructure
{
    public class PlaylistDB
    {
        public int Id { get; set; }
        public int IdUsuario { get; set; }
        public string? Titulo { get; set; } = string.Empty;
        public string? Imagem { get; set; } = string.Empty;
        public DateTime DtInsercao { get; set; } = DateTime.Now;
        public bool Ativo { get; set; } = true;
    }
}