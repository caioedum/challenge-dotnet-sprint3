using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiChallenge.Models
{
    [Table("EnderecosClinicas")]
    public class EnderecoClinica
    {
        [Key]
        public int EnderecoClinicaId { get; set; }

        public int? ClinicaId { get; set; }

        [Required]
        [StringLength(9)]
        public string? Cep { get; set; }

        [Required]
        [StringLength(80)]
        public string? Cidade { get; set; }

        [Required]
        [StringLength(2)]
        public string? Estado { get; set; }

        [Required]
        [StringLength(80)]
        public string? Logradouro { get; set; }

        [Required]
        [StringLength(80)]
        public string? Bairro { get; set; }

        // Relacionamento
        public Clinica? Clinica { get; set; }
    }
}
