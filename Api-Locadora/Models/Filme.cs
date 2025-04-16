namespace Api_Locadora.Models
{
    public class Filme
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Titulo { get; set; }
        public int Ano_Lancamento { get; set; }
        public string Diretor { get; set; }
        public Genero Genero { get; set; }
        public Estudio Estudio { get; set; }
        public double IMDB { get; set; }

    }
}
