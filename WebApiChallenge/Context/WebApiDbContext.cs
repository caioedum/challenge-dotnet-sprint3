using Microsoft.EntityFrameworkCore;
using WebApiChallenge.Models;

namespace WebApiChallenge.Context
{
    public class WebApiDbContext : DbContext
    {
        public WebApiDbContext(DbContextOptions<WebApiDbContext> options) : base(options)
        {
        }

        public DbSet<AtendimentoUsuario> T_ATENDIMENTO_USUARIO_ODONTOPREV { get; set; }
        public DbSet<Clinica> T_CLINICA_ODONTOPREV { get; set; }
        public DbSet<ContatoUsuario> T_CONTATO_USUARIO_ODONTOPREV { get; set; }
        public DbSet<Dentista> T_DENTISTA_ODONTOPREV { get; set; }
        public DbSet<EnderecoClinica> T_ENDERECO_CLINICA_ODONTOPREV { get; set; }
        public DbSet<EnderecoUsuario> T_ENDERECO_USUARIO_ODONTOPREV { get; set; }
        public DbSet<Imagem> T_IMAGEM_USUARIO_ODONTOPREV { get; set; }
        public DbSet<Previsao> T_PREVISAO_USUARIO_ODONTOPREV { get; set; }
        public DbSet<Usuario> T_USUARIO_ODONTOPREV { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>()
                .Property(u => u.UsuarioId)
                .ValueGeneratedOnAdd();
        }
    }
}
