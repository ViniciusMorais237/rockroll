namespace backend.Domain.Entities
{
    public class Musica
    {
        public Musica(string titulo, string urlMusica, List<Artista> artistas)
        {
            Titulo = titulo;
            UrlMusica = urlMusica;
            Artistas = artistas;
        }
        public int Id { get; private set; }
        public string Titulo { get; private set; } = string.Empty;
        public string UrlMusica { get; private set; } = string.Empty;
        public string UrlImagem { get; private set; } = string.Empty;
        public List<Artista> Artistas { get; private set; } = new();

        public static Musica Criar(string titulo, string urlMusica, List<Artista> artistas)
        {
            return new Musica(titulo, urlMusica, artistas);
        }

        public void AdicionarArtista(Artista artista)
        {
            Artistas.Add(artista);
        }
    }
}