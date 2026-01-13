namespace backend.Domain.Entities
{
    public class Musica
    {
        public int Id { get; set; }
        public string Titulo { get; set; } = string.Empty;
        public int IdArtista { get; set; }
        public string NomeArtista { get; set; } = string.Empty;
        public string UrlMusica { get; set; } = string.Empty;
        public string UrlImagem { get; set; } = string.Empty;
    }
}