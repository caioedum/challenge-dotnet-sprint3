using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiChallenge.Models
{
    public class Previsao
    {
        public int PrevisaoId { get; set; }

        public int? ImagemId { get; set; }

        public int? UsuarioId { get; set; }

        public string? PrevisaoTexto { get; set; }

        public float? Probabilidade { get; set; }

        public string? Recomendacao { get; set; }

        public DateTime? DataPrevisao { get; set; }

        // Relacionamentos
        public Imagem? Imagem { get; set; }
        public Usuario? Usuario { get; set; }
    }
}
