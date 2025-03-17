using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiChallenge.Models
{
    [Table("AtendimentosUsuarios")]
    public class AtendimentoUsuario
    {
        [Key]
        public int AtendimentoUsuarioId { get; set; }

        public int? UsuarioId { get; set; }

        public int? DentistaId { get; set; }

        public int? ClinicaId { get; set; }

        public DateTime DataAtendimento { get; set; }

        [Required]
        [StringLength(200)]
        public string? DescricaoProcedimento { get; set; }

        [Column(TypeName = "decimal(10, 2)")]
        public decimal Custo { get; set; }

        public DateTime DataRegistro { get; set; } = DateTime.Now;

        // Relacionamentos
        public Usuario? Usuario { get; set; }
        public Dentista? Dentista { get; set; }
        public Clinica? Clinica { get; set; }
    }
}
