namespace backend.Domain.Entities.DTOs
{
    public class CriarMusicaCommand
    {
        public string Titulo = string.Empty;
        public int IdArtista { get; set; }
        public string NomeArtista { get; set; } = string.Empty;
        public required IFormFile FileMusica { get; set; }
    }
}