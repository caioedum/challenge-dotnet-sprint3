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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>()
                .HasIndex(u => u.Cpf)
                .IsUnique();

            modelBuilder.Entity<ContatoUsuario>()
                .HasIndex(c => c.Email)
                .IsUnique();

            modelBuilder.Entity<Usuario>()
                .HasMany(u => u.Contatos)
                .WithOne(c => c.Usuario)
                .HasForeignKey(c => c.UsuarioId);

            modelBuilder.Entity<Usuario>()
                .HasMany(u => u.Enderecos)
                .WithOne(e => e.Usuario)
                .HasForeignKey(e => e.UsuarioId);

            modelBuilder.Entity<Usuario>()
                .HasMany(u => u.Imagens)
                .WithOne(i => i.Usuario)
                .HasForeignKey(i => i.UsuarioId);

            modelBuilder.Entity<Usuario>()
                .HasMany(u => u.Atendimentos)
                .WithOne(a => a.Usuario)
                .HasForeignKey(a => a.UsuarioId);

            modelBuilder.Entity<Usuario>()
                .HasOne(u => u.Dentista)
                .WithOne(d => d.Usuario)
                .HasForeignKey<Dentista>(d => d.UsuarioId);

            modelBuilder.Entity<Dentista>()
                .HasMany(d => d.Clinicas)
                .WithOne(c => c.Dentista)
                .HasForeignKey(c => c.DentistaId);

            modelBuilder.Entity<Clinica>()
                .HasMany(c => c.EnderecosClinica)
                .WithOne(e => e.Clinica)
                .HasForeignKey(e => e.ClinicaId);

            modelBuilder.Entity<ImagemUsuario>()
                .HasMany(i => i.PrevisoesUsuarios)
                .WithOne(p => p.ImagemUsuario)
                .HasForeignKey(p => p.ImagemUsuarioId);
        }

    }
}
