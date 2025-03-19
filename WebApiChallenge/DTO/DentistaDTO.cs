namespace WebApiChallenge.DTO
{
    public class DentistaDTO
    {
        public int DentistaId { get; set; }

        public int? UsuarioId { get; set; }

        public string? NomeDentista { get; set; }

        public string? Especialidade { get; set; }

        public string? TelefoneDentista { get; set; }
        public string? EmailDentista { get; set; }
    }
}
