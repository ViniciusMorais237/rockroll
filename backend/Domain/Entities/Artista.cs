namespace backend.Domain.Entities
{
    public class Artista
    {
        public Artista(string nome, string urlFoto = "")
        {
            Nome = nome;
            UrlFoto = urlFoto;
        }
        public Artista(int id, string nome)
        {
            Id = id;
            Nome = nome;
        }
        public int Id { get; private set; }
        public string Nome { get; private set; } = string.Empty;
        public int Premium { get; private set; }
        public string UrlFoto { get; private set; } = string.Empty;
        public int Seguidores { get; set; }

        public void AlterarNome(string nome)
        {
            Nome = nome;
        }

        public void AdicionarUrlFoto(string url)
        {
            UrlFoto = url;
        }

        public void DefinirComoPremium()
        {
            Premium = 1;
        }

        public static Artista Criar(string nome, string urlFoto)
        {
            return new Artista(nome, urlFoto);
        }
    }
}