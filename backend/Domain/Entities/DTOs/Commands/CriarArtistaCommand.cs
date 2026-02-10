using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Domain.Entities.DTOs.Commands
{
    public class CriarArtistaCommand
    {
        public string Nome { get; set; } = string.Empty;
        public int IdUsuario { get; set; }
        public bool Premium { get; set; }
        public IFormFile? Foto { get; set; }
    }
}