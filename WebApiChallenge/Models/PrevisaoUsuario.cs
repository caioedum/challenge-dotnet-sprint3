using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiChallenge.Models
{
    public class PrevisaoUsuario
    {
        public int PrevisaoUsuarioId { get; set; }

        public int? ImagemUsuarioId { get; set; }

        public int? UsuarioId { get; set; }

        public string? PrevisaoTexto { get; set; }

        public decimal Probabilidade { get; set; }

        public string? Recomendacao { get; set; }

        public DateTime DataPrevisao { get; set; } = DateTime.Now;

        // Relacionamentos
        public ImagemUsuario? ImagemUsuario { get; set; }
        public Usuario? Usuario { get; set; }
    }
}
