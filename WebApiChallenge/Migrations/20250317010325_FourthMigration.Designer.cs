﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Oracle.EntityFrameworkCore.Metadata;
using WebApiChallenge.Context;

#nullable disable

namespace WebApiChallenge.Migrations
{
    [DbContext(typeof(WebApiDbContext))]
    [Migration("20250317010325_FourthMigration")]
    partial class FourthMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            OracleModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("WebApiChallenge.Models.AtendimentoUsuario", b =>
                {
                    b.Property<int>("AtendimentoUsuarioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AtendimentoUsuarioId"));

                    b.Property<int?>("ClinicaId")
                        .HasColumnType("NUMBER(10)");

                    b.Property<decimal>("Custo")
                        .HasColumnType("decimal(10, 2)");

                    b.Property<DateTime>("DataAtendimento")
                        .HasColumnType("TIMESTAMP(7)");

                    b.Property<DateTime>("DataRegistro")
                        .HasColumnType("TIMESTAMP(7)");

                    b.Property<int?>("DentistaId")
                        .HasColumnType("NUMBER(10)");

                    b.Property<string>("DescricaoProcedimento")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<int?>("UsuarioId")
                        .HasColumnType("NUMBER(10)");

                    b.HasKey("AtendimentoUsuarioId");

                    b.HasIndex("ClinicaId");

                    b.HasIndex("DentistaId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("AtendimentosUsuarios");
                });

            modelBuilder.Entity("WebApiChallenge.Models.Clinica", b =>
                {
                    b.Property<int>("ClinicaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ClinicaId"));

                    b.Property<int?>("DentistaId")
                        .HasColumnType("NUMBER(10)");

                    b.Property<string>("Nome")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("Telefone")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.HasKey("ClinicaId");

                    b.HasIndex("DentistaId");

                    b.ToTable("Clinicas");
                });

            modelBuilder.Entity("WebApiChallenge.Models.ContatoUsuario", b =>
                {
                    b.Property<int>("ContatoUsuarioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ContatoUsuarioId"));

                    b.Property<string>("Email")
                        .HasColumnType("NVARCHAR2(450)");

                    b.Property<string>("Telefone")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<int?>("UsuarioId")
                        .HasColumnType("NUMBER(10)");

                    b.HasKey("ContatoUsuarioId");

                    b.HasIndex("Email")
                        .IsUnique()
                        .HasFilter("\"Email\" IS NOT NULL");

                    b.HasIndex("UsuarioId");

                    b.ToTable("ContatosUsuarios");
                });

            modelBuilder.Entity("WebApiChallenge.Models.Dentista", b =>
                {
                    b.Property<int>("DentistaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DentistaId"));

                    b.Property<string>("Email")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("Especialidade")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("Nome")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("Telefone")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<int?>("UsuarioId")
                        .HasColumnType("NUMBER(10)");

                    b.HasKey("DentistaId");

                    b.HasIndex("UsuarioId")
                        .IsUnique()
                        .HasFilter("\"UsuarioId\" IS NOT NULL");

                    b.ToTable("Dentistas");
                });

            modelBuilder.Entity("WebApiChallenge.Models.EnderecoClinica", b =>
                {
                    b.Property<int>("EnderecoClinicaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EnderecoClinicaId"));

                    b.Property<string>("Bairro")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("Cep")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("Cidade")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<int>("ClinicaId")
                        .HasColumnType("NUMBER(10)");

                    b.Property<string>("Estado")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("Logradouro")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.HasKey("EnderecoClinicaId");

                    b.HasIndex("ClinicaId");

                    b.ToTable("EnderecosClinicas");
                });

            modelBuilder.Entity("WebApiChallenge.Models.EnderecoUsuario", b =>
                {
                    b.Property<int>("EnderecoUsuarioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EnderecoUsuarioId"));

                    b.Property<string>("Bairro")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("Cep")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("Cidade")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("Estado")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("Logradouro")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<int?>("UsuarioId")
                        .HasColumnType("NUMBER(10)");

                    b.HasKey("EnderecoUsuarioId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("EnderecosUsuarios");
                });

            modelBuilder.Entity("WebApiChallenge.Models.ImagemUsuario", b =>
                {
                    b.Property<int>("ImagemUsuarioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ImagemUsuarioId"));

                    b.Property<DateTime>("DataEnvio")
                        .HasColumnType("TIMESTAMP(7)");

                    b.Property<string>("ImagemUrl")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<int?>("UsuarioId")
                        .HasColumnType("NUMBER(10)");

                    b.HasKey("ImagemUsuarioId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("ImagensUsuarios");
                });

            modelBuilder.Entity("WebApiChallenge.Models.PrevisaoUsuario", b =>
                {
                    b.Property<int>("PrevisaoUsuarioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PrevisaoUsuarioId"));

                    b.Property<DateTime>("DataPrevisao")
                        .HasColumnType("TIMESTAMP(7)");

                    b.Property<int>("ImagemUsuarioId")
                        .HasColumnType("NUMBER(10)");

                    b.Property<string>("PrevisaoTexto")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<decimal>("Probabilidade")
                        .HasColumnType("float");

                    b.Property<string>("Recomendacao")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<int?>("UsuarioId")
                        .HasColumnType("NUMBER(10)");

                    b.HasKey("PrevisaoUsuarioId");

                    b.HasIndex("ImagemUsuarioId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("PrevisoesUsuarios");
                });

            modelBuilder.Entity("WebApiChallenge.Models.Usuario", b =>
                {
                    b.Property<int>("UsuarioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UsuarioId"));

                    b.Property<string>("Cpf")
                        .HasColumnType("NVARCHAR2(450)");

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("TIMESTAMP(7)");

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("TIMESTAMP(7)");

                    b.Property<string>("Genero")
                        .HasColumnType("NVARCHAR2(1)");

                    b.Property<string>("Nome")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("Sobrenome")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.HasKey("UsuarioId");

                    b.HasIndex("Cpf")
                        .IsUnique()
                        .HasFilter("\"Cpf\" IS NOT NULL");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("WebApiChallenge.Models.AtendimentoUsuario", b =>
                {
                    b.HasOne("WebApiChallenge.Models.Clinica", "Clinica")
                        .WithMany("Atendimentos")
                        .HasForeignKey("ClinicaId");

                    b.HasOne("WebApiChallenge.Models.Dentista", "Dentista")
                        .WithMany("Atendimentos")
                        .HasForeignKey("DentistaId");

                    b.HasOne("WebApiChallenge.Models.Usuario", "Usuario")
                        .WithMany("Atendimentos")
                        .HasForeignKey("UsuarioId");

                    b.Navigation("Clinica");

                    b.Navigation("Dentista");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("WebApiChallenge.Models.Clinica", b =>
                {
                    b.HasOne("WebApiChallenge.Models.Dentista", "Dentista")
                        .WithMany("Clinicas")
                        .HasForeignKey("DentistaId");

                    b.Navigation("Dentista");
                });

            modelBuilder.Entity("WebApiChallenge.Models.ContatoUsuario", b =>
                {
                    b.HasOne("WebApiChallenge.Models.Usuario", "Usuario")
                        .WithMany("Contatos")
                        .HasForeignKey("UsuarioId");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("WebApiChallenge.Models.Dentista", b =>
                {
                    b.HasOne("WebApiChallenge.Models.Usuario", "Usuario")
                        .WithOne("Dentista")
                        .HasForeignKey("WebApiChallenge.Models.Dentista", "UsuarioId");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("WebApiChallenge.Models.EnderecoClinica", b =>
                {
                    b.HasOne("WebApiChallenge.Models.Clinica", "Clinica")
                        .WithMany("EnderecosClinica")
                        .HasForeignKey("ClinicaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Clinica");
                });

            modelBuilder.Entity("WebApiChallenge.Models.EnderecoUsuario", b =>
                {
                    b.HasOne("WebApiChallenge.Models.Usuario", "Usuario")
                        .WithMany("Enderecos")
                        .HasForeignKey("UsuarioId");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("WebApiChallenge.Models.ImagemUsuario", b =>
                {
                    b.HasOne("WebApiChallenge.Models.Usuario", "Usuario")
                        .WithMany("Imagens")
                        .HasForeignKey("UsuarioId");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("WebApiChallenge.Models.PrevisaoUsuario", b =>
                {
                    b.HasOne("WebApiChallenge.Models.ImagemUsuario", "ImagemUsuario")
                        .WithMany("PrevisoesUsuarios")
                        .HasForeignKey("ImagemUsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApiChallenge.Models.Usuario", "Usuario")
                        .WithMany("Previsoes")
                        .HasForeignKey("UsuarioId");

                    b.Navigation("ImagemUsuario");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("WebApiChallenge.Models.Clinica", b =>
                {
                    b.Navigation("Atendimentos");

                    b.Navigation("EnderecosClinica");
                });

            modelBuilder.Entity("WebApiChallenge.Models.Dentista", b =>
                {
                    b.Navigation("Atendimentos");

                    b.Navigation("Clinicas");
                });

            modelBuilder.Entity("WebApiChallenge.Models.ImagemUsuario", b =>
                {
                    b.Navigation("PrevisoesUsuarios");
                });

            modelBuilder.Entity("WebApiChallenge.Models.Usuario", b =>
                {
                    b.Navigation("Atendimentos");

                    b.Navigation("Contatos");

                    b.Navigation("Dentista");

                    b.Navigation("Enderecos");

                    b.Navigation("Imagens");

                    b.Navigation("Previsoes");
                });
#pragma warning restore 612, 618
        }
    }
}
