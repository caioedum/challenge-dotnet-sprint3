namespace WebApiChallenge.Models
{
    public class ContatoUsuario
    {
        public int ContatoUsuarioId { get; set; }
        public int? UsuarioId { get; set; }
        public string? Email { get; set; }
        public string? Telefone { get; set; }

        // Relacionamento
        public Usuario? Usuario { get; set; }
    }
}
