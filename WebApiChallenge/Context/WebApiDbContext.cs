using Microsoft.EntityFrameworkCore;
using WebApiChallenge.Models;

namespace WebApiChallenge.Context
{
    public class WebApiDbContext : DbContext
    {
        public WebApiDbContext(DbContextOptions<WebApiDbContext> options) : base(options)
        {
        }
        public DbSet<AtendimentoUsuario> AtendimentosUsuarios { get; set; }
        public DbSet<Clinica> Clinicas { get; set; }
        public DbSet<ContatoUsuario> ContatosUsuarios { get; set; }
        public DbSet<Dentista> Dentistas { get; set; }
        public DbSet<EnderecoClinica> EnderecosClinicas { get; set; }
        public DbSet<EnderecoUsuario> EnderecosUsuarios { get; set; }
        public DbSet<ImagemUsuario> ImagensUsuarios { get; set; }
        public DbSet<PrevisaoUsuario> PrevisoesUsuarios { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
    }
}
