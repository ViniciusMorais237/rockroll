using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Domain.Entities.Infrastructure
{
    public class UsuarioDB
    {
        public int IdUsuario { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string SenhaHash { get; set; }
        public bool IsArtista { get; set; }
        public string? NomeArquivoImagem { get; set; }
    }
}