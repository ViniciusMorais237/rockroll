namespace backend.Domain.Entities
{
    public class Musica
    {

        public Musica(int id, string titulo, string urlMusica)
        {
            Id = id;
            Titulo = titulo;
            UrlMusica = urlMusica;
        }
        public Musica(string titulo, int idArtista, string urlMusica)
        {
            Titulo = titulo;
            UrlMusica = urlMusica;
            IdArtista = idArtista;
        }

        public int Id { get; private set; }
        public string Titulo { get; private set; } = string.Empty;
        public string UrlMusica { get; private set; } = string.Empty;
        public string UrlImagem { get; private set; } = string.Empty;
        public int IdArtista { get; private set; }

        public static Musica Criar(string titulo, int idArtista, string urlMusica)
        {
            return new Musica(titulo, idArtista, urlMusica);
        }

        public static Musica Restaurar(int id, string titulo, string urlMusica)
        {
            return new Musica(id, titulo, urlMusica);
        }
    }
}