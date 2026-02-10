using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Domain.Entities.Infrastructure
{
    public class MusicaPlaylistDB
    {
        public int Id { get; set; }
        public int IdPlaylist { get; set; }
        public int IdMusica { get; set; }
        public DateTime DtAtualizacao { get; set; } = DateTime.Now;
        public bool Ativo { get; set; } = true;
    }
}