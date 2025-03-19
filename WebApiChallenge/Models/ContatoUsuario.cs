using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiChallenge.Models
{
    public class ContatoUsuario
    {
        public int ContatoUsuarioId { get; set; }

        public int? UsuarioId { get; set; }

        public string? EmailUsuario { get; set; }

        public string? TelefoneUsuario { get; set; }

        // Relacionamento
        public Usuario? Usuario { get; set; }
    }
}
