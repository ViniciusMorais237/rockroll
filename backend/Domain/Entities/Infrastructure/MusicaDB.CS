namespace backend.Domain.Entities.Infrastructure;

public class MusicaDB
{
    public int Id { get; set; }
    public int IdArtista { get; set; }
    public string Titulo { get; set; } = string.Empty;
    public string UrlMusica { get; set; } = string.Empty;
    public string UrlImagem { get; set; } = string.Empty;
    public DateTime DtInsercao { get; set; } = DateTime.Now;
    public bool Ativo { get; set; } = true;
}