namespace WebApiChallenge.DTO
{
    public class UsuarioCreateDTO
    {
        public string? Cpf { get; set; }
        public string? Nome { get; set; }
        public string? Sobrenome { get; set; }
        public DateTime DataNascimento { get; set; }
        public char? Genero { get; set; }
        public DateTime DataCadastro { get; set; }
    }
}
