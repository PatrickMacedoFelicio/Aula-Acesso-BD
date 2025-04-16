using Api_Locadora.Models;
using System.ComponentModel.DataAnnotations;

namespace Api_Locadora.Dtos
{
    public class FilmeDto
    {
        [Required] // indica que o campo é obrigatorio
        public string Titulo { get; set; }
        [Required]
        public int Ano_Lancamento { get; set; }
        [Required]
        public string Diretor { get; set; }
        [Required]
        public Genero Genero { get; set; }
        [Required]
        public Estudio Estudio { get; set; }
        [Required]
        public double IMDB { get; set; }
    }
}
