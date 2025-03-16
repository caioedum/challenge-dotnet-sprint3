namespace WebApiChallenge.Models
{
    public class Atendimento
    {
        public int AtendimentoId { get; set; }
        public int UsuarioId { get; set; }
        public int DentistaId { get; set; }
        public int ClinicaId { get; set; }
        public DateTime DataAtendimento { get; set; }
        public string? Descricao { get; set; }
        public decimal Custo { get; set; }
        public DateTime DataRegistro { get; set; }
    }
}
