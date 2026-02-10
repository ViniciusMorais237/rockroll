using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Domain.Entities.DTOs.Queries
{
    public class PlaylistSelect
    {
        public int Id { get; set; }
        public string? Titulo { get; set; } = string.Empty;
    }
}