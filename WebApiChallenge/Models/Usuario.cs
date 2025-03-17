using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiChallenge.Models
{
    [Table("Usuarios")]
    public class Usuario
    {
        [Key]
        public int UsuarioId { get; set; }

        [Required]
        [StringLength(11)]
        public string? Cpf { get; set; }

        [Required]
        [StringLength(80)]
        public string? Nome { get; set; }

        [Required]
        [StringLength(80)]
        public string? Sobrenome { get; set; }

        public DateTime DataNascimento { get; set; }

        [Required]
        [StringLength(1)]
        public char? Genero { get; set; }

        public DateTime DataCadastro { get; set; } = DateTime.Now;

        // Relacionamentos
        public ICollection<ContatoUsuario>? Contatos { get; set; }
        public ICollection<EnderecoUsuario>? Enderecos { get; set; }
        public ICollection<ImagemUsuario>? Imagens { get; set; }
        public ICollection<AtendimentoUsuario>? Atendimentos { get; set; }
        public ICollection<PrevisaoUsuario>? Previsoes { get; set; }
        public Dentista? Dentista { get; set; }

        public Usuario()
        {
            Contatos = new Collection<ContatoUsuario>();
            Enderecos = new Collection<EnderecoUsuario>();
            Imagens = new Collection<ImagemUsuario>();
            Atendimentos = new Collection<AtendimentoUsuario>();
            Previsoes = new Collection<PrevisaoUsuario>();
        }
    }
}
