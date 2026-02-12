using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Domain.Entities.DTOs.Queries
{
    public class MusicaResponse
    {
        public int Id { get;  set; }
        public string Titulo { get;  set; } = string.Empty;
        public string UrlMusica { get;  set; } = string.Empty;
        public string? UrlImagem { get;  set; } = string.Empty;
    }
}