using System.ComponentModel.DataAnnotations;

namespace Api_Locadora.Dtos
{
    public class FilmeDto
    {
        [Required] // indica que o campo é obrigatorio
        public string Nome { get; set; }
        [Required]
        public string Genero { get; set; }
    }
}
