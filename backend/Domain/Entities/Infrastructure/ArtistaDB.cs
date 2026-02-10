using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Domain.Entities.Infrastructure
{
    public class ArtistaDB
    {
        public int Id { get; set; }
        public int IdUsuario { get; set; }
        public string Nome { get; set; } = string.Empty;
        public bool Premium { get; set; }
        public string UrlFoto { get; set; } = string.Empty;
        public DateTime DtInsercao { get; set; } = DateTime.Now;
        public bool Ativo { get; set; } = true;
    }
}