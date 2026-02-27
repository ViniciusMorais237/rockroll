namespace backend.Domain.Entities
{
    public class Musica
    {
        public Musica(int? id, string titulo, int idArtista, string urlMusica, string urlImagem)
        {
            Id = id;
            Titulo = titulo;
            UrlMusica = urlMusica;
            UrlImagem = urlImagem;;
            IdArtista = idArtista;
        }

        public int? Id { get; private set; }
        public string Titulo { get; private set; } = string.Empty;
        public string UrlMusica { get; private set; } = string.Empty;
        public string UrlImagem { get; private set; } = string.Empty;
        public int IdArtista { get; private set; }

        public static Musica Criar(string titulo, int idArtista, string urlMusica, string urlImagem)
        {
            if (idArtista <= 0) throw new Exception("Não é possivel criar música sem artista");
            return new Musica(null, titulo, idArtista, urlMusica, urlImagem);
        }

        public static Musica Restaurar(int id, string titulo, int idArtista, string urlMusica, string urlImagem)
        {
            return new Musica(id, titulo, idArtista, urlMusica, urlImagem);
        }
    }
}