namespace ApiLocadora.Models
{
    public class Estudio
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public ICollection<Filme> Filmes { get; set; }

    }
}
