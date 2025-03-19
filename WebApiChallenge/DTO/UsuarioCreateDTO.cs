using System.ComponentModel.DataAnnotations;
using WebApiChallenge.Validations;

namespace WebApiChallenge.DTO
{
    public class UsuarioCreateDTO
    {
        [Required]
        public string? Cpf { get; set; }

        [Required]
        public string? Nome { get; set; }

        [Required]
        public string? Sobrenome { get; set; }

        public DateTime? DataNascimento { get; set; }

        [Required]
        [Genero("M", "F")]
        public string? Genero { get; set; }

        public DateTime? DataCadastro { get; set; }
    }
}
