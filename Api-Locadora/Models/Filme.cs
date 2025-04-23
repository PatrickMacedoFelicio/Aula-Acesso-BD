using System.ComponentModel.DataAnnotations.Schema;

namespace Api_Locadora.Models
{
    [Table("filmes")]
    public class Filme
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("titulo")]
        public string? Titulo { get; set; }

        [Column("ano_lancamento")]
        public DateTime? Ano_Lancamento { get; set; }

        [Column("diretor")]
        public string? Diretor { get; set; }

        //public Genero Genero { get; set; }
        //public Estudio Estudio { get; set; }

        [Column("imdb")]
        public double IMDB { get; set; }

    }
}
