using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiChallenge.Models
{
    public class Imagem
    {
        public int ImagemId { get; set; }

        public int? UsuarioId { get; set; }

        public string? ImagemUrl { get; set; }

        public DateTime DataEnvio { get; set; } = DateTime.Now;

        // Relacionamentos
        public Usuario? Usuario { get; set; }
        public ICollection<Previsao>? Previsoes { get; set; }

        public Imagem()
        {
            Previsoes = new Collection<Previsao>();
        }
    }
}
