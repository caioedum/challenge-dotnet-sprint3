namespace WebApiChallenge.DTO
{
    public class PrevisaoDTO
    {
        public int PrevisaoId { get; set; }

        public int? ImagemId { get; set; }

        public int? UsuarioId { get; set; }

        public string? PrevisaoTexto { get; set; }

        public float? Probabilidade { get; set; }

        public string? Recomendacao { get; set; }

        public DateTime? DataPrevisao { get; set; }
    }
}
