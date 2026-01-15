namespace backend.Domain.Entities
{
    public class Artista
    {
        public Artista(int id, string nome)
        {
            Id = id;
            Nome = nome;
        }
        public int Id { get; private set; }
        public string Nome { get; private set; } = string.Empty;
        public int Seguidores { get; set; }

        public void AlterarNome(string nome)
        {
            Nome = nome;
        }
    }
}