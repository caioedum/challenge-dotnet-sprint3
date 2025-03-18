using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiChallenge.Models
{
    [Table("ContatosUsuarios")]
    public class ContatoUsuario
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ContatoUsuarioId { get; set; }

        public int? UsuarioId { get; set; }

        [Required]
        [StringLength(80)]
        public string? Email { get; set; }

        [Required]
        [StringLength(25)]
        public string? Telefone { get; set; }

        // Relacionamento
        public Usuario? Usuario { get; set; }
    }
}
