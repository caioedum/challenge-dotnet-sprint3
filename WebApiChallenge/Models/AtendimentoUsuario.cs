using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiChallenge.Models
{
    public class AtendimentoUsuario
    {
        public int AtendimentoUsuarioId { get; set; }

        public int? UsuarioId { get; set; }

        public int? DentistaId { get; set; }

        public int? ClinicaId { get; set; }

        public DateTime DataAtendimento { get; set; }

        public string? DescricaoProcedimento { get; set; }

        public decimal Custo { get; set; }

        public DateTime DataRegistro { get; set; } = DateTime.Now;

        // Relacionamentos
        public Usuario? Usuario { get; set; }
        public Dentista? Dentista { get; set; }
        public Clinica? Clinica { get; set; }
    }
}
