using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Domain.Entities.Infrastructure
{
    public class MusicaAlbumDB
    {
        public int Id { get; set; }
        public int IdAlbum { get; set; }
        public int IdMusica { get; set; }
        public DateTime DtAtualizacao { get; set; } = DateTime.Now;
        public bool Ativo { get; set; } = true;
    }
}