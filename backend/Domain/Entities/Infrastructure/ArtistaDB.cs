using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Domain.Entities.Infrastructure
{
    public class ArtistaDB
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public int Premium { get; set; }
        public string UrlFoto { get; set; } = string.Empty;
        public DateTime DtInsercao { get; set; } = DateTime.Now;
        public int Ativo { get; set; } = 1;
    }
}