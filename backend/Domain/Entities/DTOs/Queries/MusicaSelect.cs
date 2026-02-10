using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Domain.Entities.DTOs.Queries
{
    public class MusicaSelect
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
    }
}