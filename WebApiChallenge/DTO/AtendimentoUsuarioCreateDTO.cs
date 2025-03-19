namespace WebApiChallenge.DTO
{
    public class AtendimentoUsuarioCreateDTO
    {
        public int UsuarioId { get; set; }

        public int DentistaId { get; set; }

        public int ClinicaId { get; set; }

        public DateTime DataAtendimento { get; set; }

        public string? DescricaoProcedimento { get; set; }

        public decimal Custo { get; set; }

        public DateTime DataRegistro { get; set; }
    }
}
