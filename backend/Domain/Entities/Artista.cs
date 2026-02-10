namespace backend.Domain.Entities
{
    public class Artista
    {
        public Artista(int? id, string nome, bool premium, string urlFoto = "")
        {
            Id = id;
            Nome = nome;
            UrlFoto = urlFoto;
            Premium = premium;
        }
        public int? Id { get; private set; }
        public string Nome { get; private set; } = string.Empty;
        public bool Premium { get; private set; }
        public string UrlFoto { get; private set; } = string.Empty;
        public int Seguidores { get; set; }
        public List<Musica>? Musicas { get; set; }

        public void AlterarNome(string nome)
        {
            Nome = nome;
        }

        public void AdicionarUrlFoto(string url)
        {
            UrlFoto = url;
        }

        public void AdicionarMusicas(IEnumerable<Musica> musicas)
        {
            Musicas ??= [];
            Musicas.AddRange(musicas);
        }

        public void DefinirComoPremium()
        {
            Premium = true;
        }

        public static Artista Criar(int? id, string nome, bool premium, string urlFoto)
        {
            return new Artista(id, nome, premium, urlFoto);
        }

        public void DefinirSeguidores()
        {

        }
    }
}