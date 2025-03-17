using System.Collections.ObjectModel;

namespace WebApiChallenge.Models
{
    public class Usuario
    {
        public int UsuarioId { get; set; }
        public string? Cpf { get; set; }
        public string? Nome { get; set; }
        public string? Sobrenome { get; set; }
        public DateTime DataNascimento { get; set; }
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
