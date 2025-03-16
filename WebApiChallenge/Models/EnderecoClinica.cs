namespace WebApiChallenge.Models
{
    public class EnderecoClinica
    {
        public int EnderecoClinicaId { get; set; }
        public int ClinicaId { get; set; }
        public string? Cep { get; set; }
        public string? Cidade { get; set; }
        public string? Estado { get; set; }
        public string? Logradouro { get; set; }
        public string? Bairro { get; set; }

        // Relacionamento
        public Clinica? Clinica { get; set; }
    }
}
