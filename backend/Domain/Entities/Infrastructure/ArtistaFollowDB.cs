using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Domain.Entities.Infrastructure
{
    public class ArtistaFollowDB
    {
        public int Id { get; set; }
        public int IdArtista { get; set; }
        public int IdUsuario { get; set; }
        public DateTime DataAtualizacao { get; set; } = DateTime.Now;
        public bool Ativo { get; set; } = true;
    }
}