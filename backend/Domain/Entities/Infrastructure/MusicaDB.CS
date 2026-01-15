namespace backend.Domain.Entities.Infrastructure;

public class MusicaDB
{
    public int Id { get; set; }
    public string Titulo { get; set; } = string.Empty;
    public string UrlMusica { get; set; } = string.Empty;
    public string UrlImagem { get; set; } = string.Empty;
    public DateTime DtInsercao { get; set; } = DateTime.Now;
    public int Ativo { get; set; } = 1;
}