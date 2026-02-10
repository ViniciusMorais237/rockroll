using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Domain.Entities.DTOs.Commands
{
    public class CriarPlaylistCommand
    {
        public int IdUsuario { get; set; }
        public string? Titulo { get; set; } = string.Empty;
        public IFormFile? Imagem { get; set; }
    }
}