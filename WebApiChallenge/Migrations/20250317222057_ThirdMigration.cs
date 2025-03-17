using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApiChallenge.Migrations
{
    /// <inheritdoc />
    public partial class ThirdMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    UsuarioId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Cpf = table.Column<string>(type: "NVARCHAR2(11)", maxLength: 11, nullable: false),
                    Nome = table.Column<string>(type: "NVARCHAR2(80)", maxLength: 80, nullable: false),
                    Sobrenome = table.Column<string>(type: "NVARCHAR2(80)", maxLength: 80, nullable: false),
                    DataNascimento = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    Genero = table.Column<string>(type: "NVARCHAR2(1)", maxLength: 1, nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.UsuarioId);
                });

            migrationBuilder.CreateTable(
                name: "ContatosUsuarios",
                columns: table => new
                {
                    ContatoUsuarioId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    UsuarioId = table.Column<int>(type: "NUMBER(10)", nullable: true),
                    Email = table.Column<string>(type: "NVARCHAR2(80)", maxLength: 80, nullable: false),
                    Telefone = table.Column<string>(type: "NVARCHAR2(25)", maxLength: 25, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContatosUsuarios", x => x.ContatoUsuarioId);
                    table.ForeignKey(
                        name: "FK_ContatosUsuarios_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "UsuarioId");
                });

            migrationBuilder.CreateTable(
                name: "Dentistas",
                columns: table => new
                {
                    DentistaId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    UsuarioId = table.Column<int>(type: "NUMBER(10)", nullable: true),
                    Nome = table.Column<string>(type: "NVARCHAR2(80)", maxLength: 80, nullable: false),
                    Especialidade = table.Column<string>(type: "NVARCHAR2(120)", maxLength: 120, nullable: false),
                    Telefone = table.Column<string>(type: "NVARCHAR2(25)", maxLength: 25, nullable: false),
                    Email = table.Column<string>(type: "NVARCHAR2(80)", maxLength: 80, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dentistas", x => x.DentistaId);
                    table.ForeignKey(
                        name: "FK_Dentistas_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "UsuarioId");
                });

            migrationBuilder.CreateTable(
                name: "EnderecosUsuarios",
                columns: table => new
                {
                    EnderecoUsuarioId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    UsuarioId = table.Column<int>(type: "NUMBER(10)", nullable: true),
                    Cep = table.Column<string>(type: "NVARCHAR2(9)", maxLength: 9, nullable: false),
                    Cidade = table.Column<string>(type: "NVARCHAR2(80)", maxLength: 80, nullable: false),
                    Estado = table.Column<string>(type: "NVARCHAR2(2)", maxLength: 2, nullable: false),
                    Logradouro = table.Column<string>(type: "NVARCHAR2(80)", maxLength: 80, nullable: false),
                    Bairro = table.Column<string>(type: "NVARCHAR2(80)", maxLength: 80, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnderecosUsuarios", x => x.EnderecoUsuarioId);
                    table.ForeignKey(
                        name: "FK_EnderecosUsuarios_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "UsuarioId");
                });

            migrationBuilder.CreateTable(
                name: "ImagensUsuarios",
                columns: table => new
                {
                    ImagemUsuarioId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    UsuarioId = table.Column<int>(type: "NUMBER(10)", nullable: true),
                    ImagemUrl = table.Column<string>(type: "NVARCHAR2(255)", maxLength: 255, nullable: false),
                    DataEnvio = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImagensUsuarios", x => x.ImagemUsuarioId);
                    table.ForeignKey(
                        name: "FK_ImagensUsuarios_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "UsuarioId");
                });

            migrationBuilder.CreateTable(
                name: "Clinicas",
                columns: table => new
                {
                    ClinicaId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    DentistaId = table.Column<int>(type: "NUMBER(10)", nullable: true),
                    Nome = table.Column<string>(type: "NVARCHAR2(80)", maxLength: 80, nullable: false),
                    Telefone = table.Column<string>(type: "NVARCHAR2(25)", maxLength: 25, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clinicas", x => x.ClinicaId);
                    table.ForeignKey(
                        name: "FK_Clinicas_Dentistas_DentistaId",
                        column: x => x.DentistaId,
                        principalTable: "Dentistas",
                        principalColumn: "DentistaId");
                });

            migrationBuilder.CreateTable(
                name: "PrevisoesUsuarios",
                columns: table => new
                {
                    PrevisaoUsuarioId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    ImagemUsuarioId = table.Column<int>(type: "NUMBER(10)", nullable: true),
                    UsuarioId = table.Column<int>(type: "NUMBER(10)", nullable: true),
                    PrevisaoTexto = table.Column<string>(type: "NVARCHAR2(255)", maxLength: 255, nullable: false),
                    Probabilidade = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Recomendacao = table.Column<string>(type: "NVARCHAR2(255)", maxLength: 255, nullable: false),
                    DataPrevisao = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrevisoesUsuarios", x => x.PrevisaoUsuarioId);
                    table.ForeignKey(
                        name: "FK_PrevisoesUsuarios_ImagensUsuarios_ImagemUsuarioId",
                        column: x => x.ImagemUsuarioId,
                        principalTable: "ImagensUsuarios",
                        principalColumn: "ImagemUsuarioId");
                    table.ForeignKey(
                        name: "FK_PrevisoesUsuarios_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "UsuarioId");
                });

            migrationBuilder.CreateTable(
                name: "AtendimentosUsuarios",
                columns: table => new
                {
                    AtendimentoUsuarioId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    UsuarioId = table.Column<int>(type: "NUMBER(10)", nullable: true),
                    DentistaId = table.Column<int>(type: "NUMBER(10)", nullable: true),
                    ClinicaId = table.Column<int>(type: "NUMBER(10)", nullable: true),
                    DataAtendimento = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    DescricaoProcedimento = table.Column<string>(type: "NVARCHAR2(200)", maxLength: 200, nullable: false),
                    Custo = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    DataRegistro = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AtendimentosUsuarios", x => x.AtendimentoUsuarioId);
                    table.ForeignKey(
                        name: "FK_AtendimentosUsuarios_Clinicas_ClinicaId",
                        column: x => x.ClinicaId,
                        principalTable: "Clinicas",
                        principalColumn: "ClinicaId");
                    table.ForeignKey(
                        name: "FK_AtendimentosUsuarios_Dentistas_DentistaId",
                        column: x => x.DentistaId,
                        principalTable: "Dentistas",
                        principalColumn: "DentistaId");
                    table.ForeignKey(
                        name: "FK_AtendimentosUsuarios_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "UsuarioId");
                });

            migrationBuilder.CreateTable(
                name: "EnderecosClinicas",
                columns: table => new
                {
                    EnderecoClinicaId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    ClinicaId = table.Column<int>(type: "NUMBER(10)", nullable: true),
                    Cep = table.Column<string>(type: "NVARCHAR2(9)", maxLength: 9, nullable: false),
                    Cidade = table.Column<string>(type: "NVARCHAR2(80)", maxLength: 80, nullable: false),
                    Estado = table.Column<string>(type: "NVARCHAR2(2)", maxLength: 2, nullable: false),
                    Logradouro = table.Column<string>(type: "NVARCHAR2(80)", maxLength: 80, nullable: false),
                    Bairro = table.Column<string>(type: "NVARCHAR2(80)", maxLength: 80, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnderecosClinicas", x => x.EnderecoClinicaId);
                    table.ForeignKey(
                        name: "FK_EnderecosClinicas_Clinicas_ClinicaId",
                        column: x => x.ClinicaId,
                        principalTable: "Clinicas",
                        principalColumn: "ClinicaId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AtendimentosUsuarios_ClinicaId",
                table: "AtendimentosUsuarios",
                column: "ClinicaId");

            migrationBuilder.CreateIndex(
                name: "IX_AtendimentosUsuarios_DentistaId",
                table: "AtendimentosUsuarios",
                column: "DentistaId");

            migrationBuilder.CreateIndex(
                name: "IX_AtendimentosUsuarios_UsuarioId",
                table: "AtendimentosUsuarios",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Clinicas_DentistaId",
                table: "Clinicas",
                column: "DentistaId");

            migrationBuilder.CreateIndex(
                name: "IX_ContatosUsuarios_Email",
                table: "ContatosUsuarios",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ContatosUsuarios_UsuarioId",
                table: "ContatosUsuarios",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Dentistas_UsuarioId",
                table: "Dentistas",
                column: "UsuarioId",
                unique: true,
                filter: "\"UsuarioId\" IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_EnderecosClinicas_ClinicaId",
                table: "EnderecosClinicas",
                column: "ClinicaId");

            migrationBuilder.CreateIndex(
                name: "IX_EnderecosUsuarios_UsuarioId",
                table: "EnderecosUsuarios",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_ImagensUsuarios_UsuarioId",
                table: "ImagensUsuarios",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_PrevisoesUsuarios_ImagemUsuarioId",
                table: "PrevisoesUsuarios",
                column: "ImagemUsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_PrevisoesUsuarios_UsuarioId",
                table: "PrevisoesUsuarios",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_Cpf",
                table: "Usuarios",
                column: "Cpf",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AtendimentosUsuarios");

            migrationBuilder.DropTable(
                name: "ContatosUsuarios");

            migrationBuilder.DropTable(
                name: "EnderecosClinicas");

            migrationBuilder.DropTable(
                name: "EnderecosUsuarios");

            migrationBuilder.DropTable(
                name: "PrevisoesUsuarios");

            migrationBuilder.DropTable(
                name: "Clinicas");

            migrationBuilder.DropTable(
                name: "ImagensUsuarios");

            migrationBuilder.DropTable(
                name: "Dentistas");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
