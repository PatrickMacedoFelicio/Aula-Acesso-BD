using System.ComponentModel.DataAnnotations;

namespace Api_Locadora.Dtos
{
    public class EstudioDto
    {
        [Required]
        public Guid Id { get; set; } = Guid.NewGuid();
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Distribuidor { get; set; }
    }
}
