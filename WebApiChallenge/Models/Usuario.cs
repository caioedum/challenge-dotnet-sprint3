namespace WebApiChallenge.Models
{
    public class Usuario
    {
        public int UsuarioId { get; set; }
        public string? Cpf { get; set; }
        public string? Nome { get; set; }
        public string? Sobrenome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string? Genero { get; set; }
        public DateTime DataCadastro { get; set; }
    }
}
