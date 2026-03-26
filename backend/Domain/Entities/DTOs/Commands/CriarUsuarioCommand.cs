using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Domain.Entities.DTOs.Commands
{
    public class CriarUsuarioCommand
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public bool IsArtista { get; set; }
        public IFormFile? Imagem { get; set; }
    }
}