using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiChallenge.Models
{
    [Table("EnderecosUsuarios")]
    public class EnderecoUsuario
    {
        [Key]
        public int EnderecoUsuarioId { get; set; }

        public int? UsuarioId { get; set; }

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
        public Usuario? Usuario { get; set; }
    }
}
