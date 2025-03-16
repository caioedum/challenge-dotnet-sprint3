namespace WebApiChallenge.Models
{
    public class Clinica
    {
        public int ClinicaId { get; set; }
        public int? DentistaId { get; set; }
        public string? Nome { get; set; }
        public string? Telefone { get; set; }

        // Relacionamentos
        public Dentista? Dentista { get; set; }
        public ICollection<EnderecoClinica>? EnderecosClinica { get; set; }
        public ICollection<AtendimentoUsuario>? Atendimentos { get; set; }
    }
}
