using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiChallenge.Models
{
    [Table("Dentistas")]
    public class Dentista
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DentistaId { get; set; }

        public int? UsuarioId { get; set; }

        [Required]
        [StringLength(80)]
        public string? Nome { get; set; }

        [Required]
        [StringLength(120)]
        public string? Especialidade { get; set; }

        [Required]
        [StringLength(25)]
        public string? Telefone { get; set; }

        [Required]
        [StringLength(80)]
        public string? Email { get; set; }

        // Relacionamentos
        public Usuario? Usuario { get; set; }
        public ICollection<Clinica>? Clinicas { get; set; }
        public ICollection<AtendimentoUsuario>? Atendimentos { get; set; }

        public Dentista()
        {
            Clinicas = new Collection<Clinica>();
            Atendimentos = new Collection<AtendimentoUsuario>();
        }
    }
}
