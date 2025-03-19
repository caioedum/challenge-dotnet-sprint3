namespace WebApiChallenge.DTO
{
    public class ContatoUsuarioDTO
    {
        public int ContatoUsuarioId { get; set; }

        public int? UsuarioId { get; set; }

        public string? EmailUsuario { get; set; }

        public string? TelefoneUsuario { get; set; }
    }
}
