using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiChallenge.Models
{
    [Table("PrevisoesUsuarios")]
    public class PrevisaoUsuario
    {
        [Key]
        public int PrevisaoUsuarioId { get; set; }

        public int? ImagemUsuarioId { get; set; }

        public int? UsuarioId { get; set; }

        [Required]
        [StringLength(255)]
        public string? PrevisaoTexto { get; set; }

        [Column(TypeName = "float")]
        public double Probabilidade { get; set; }

        [Required]
        [StringLength(255)]
        public string? Recomendacao { get; set; }

        public DateTime DataPrevisao { get; set; } = DateTime.Now;

        // Relacionamentos
        public ImagemUsuario? ImagemUsuario { get; set; }
        public Usuario? Usuario { get; set; }
    }
}
