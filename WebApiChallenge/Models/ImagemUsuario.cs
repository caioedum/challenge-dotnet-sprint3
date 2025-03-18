using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiChallenge.Models
{
    [Table("ImagensUsuarios")]
    public class ImagemUsuario
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ImagemUsuarioId { get; set; }

        public int? UsuarioId { get; set; }

        [Required]
        [StringLength(255)]
        public string? ImagemUrl { get; set; }

        public DateTime DataEnvio { get; set; } = DateTime.Now;

        // Relacionamentos
        public Usuario? Usuario { get; set; }
        public ICollection<PrevisaoUsuario>? PrevisoesUsuarios { get; set; }

        public ImagemUsuario()
        {
            PrevisoesUsuarios = new Collection<PrevisaoUsuario>();
        }
    }
}
