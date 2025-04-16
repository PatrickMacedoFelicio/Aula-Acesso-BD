using System.ComponentModel.DataAnnotations;

namespace Api_Locadora.Dtos
{
    public class GeneroDto
    {
        [Required]
        public Guid Id { get; set; } = Guid.NewGuid();
        [Required]
        public string Nome { get; set; }
    }
}
