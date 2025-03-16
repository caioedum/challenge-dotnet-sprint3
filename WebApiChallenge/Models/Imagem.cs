namespace WebApiChallenge.Models
{
    public class Imagem
    {
        public int ImagemId { get; set; }
        public int UsuarioId { get; set; }
        public string? ImagemUrl { get; set; }
        public DateTime DataEnvio { get; set; }
    }
}
