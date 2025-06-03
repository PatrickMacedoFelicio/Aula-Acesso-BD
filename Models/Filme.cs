using System.ComponentModel.DataAnnotations.Schema;

namespace ApiLocadora.Models
{
    [Table("filmes")]
    public class Filme
    {
        public int Id { get; set; }

        public required string Nome { get; set; }

        public required string Genero { get; set; }

        public DateTime? AnoLancamento { get; set; }

        public virtual Estudio? Estudio { get; set; }
    }
}
