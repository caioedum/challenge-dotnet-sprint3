namespace WebApiChallenge.Models
{
    public class EnderecoUsuario
    {
        public int EnderecoUsuarioId { get; set; }
        public int UsuarioId { get; set; }
        public string? Cep { get; set; }
        public string? Cidade { get; set; }
        public string? Estado { get; set; }
        public string? Logradouro { get; set; }
        public string? Bairro { get; set; }
    }
}
