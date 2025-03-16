namespace WebApiChallenge.Models
{
    public class Contato
    {
        public int ContatoId { get; set; }
        public int UsuarioId { get; set; }
        public string? Email { get; set; }
        public string? Telefone { get; set; }
    }
}
