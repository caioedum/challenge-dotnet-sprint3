using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApiChallenge.Migrations
{
    /// <inheritdoc />
    public partial class DataPopulation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Inserir dois usuários
            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "UsuarioId", "Cpf", "Nome", "Sobrenome", "DataNascimento", "Genero", "DataCadastro" },
                values: new object[,]
                {
                    { 1, "12345678901", "João", "Silva", new DateTime(1990, 1, 10), "M", DateTime.Now },
                    { 2, "98765432100", "Maria", "Oliveira", new DateTime(1985, 5, 20), "F", DateTime.Now }
                });

            // Inserir contatos para os usuários
            migrationBuilder.InsertData(
                table: "ContatosUsuarios",
                columns: new[] { "ContatoUsuarioId", "UsuarioId", "Email", "Telefone" },
                values: new object[,]
                {
                    { 1, 1, "joao.silva@example.com", "(11)99999-1111" },
                    { 2, 2, "maria.oliveira@example.com", "(21)98888-2222" }
                });

            // Inserir dentistas
            migrationBuilder.InsertData(
                table: "Dentistas",
                columns: new[] { "DentistaId", "UsuarioId", "Nome", "Especialidade", "Telefone", "Email" },
                values: new object[,]
                {
                    { 1, null, "Dr. Carlos Mendes", "Ortodontia", "(11)3333-4444", "carlos.mendes@clinica.com" },
                    { 2, null, "Dra. Ana Paula Lima", "Endodontia", "(21)5555-6666", "ana.lima@clinica.com" }
                });

            // Inserir clínicas associadas aos dentistas
            migrationBuilder.InsertData(
                table: "Clinicas",
                columns: new[] { "ClinicaId", "DentistaId", "Nome", "Telefone" },
                values: new object[,]
                {
                    { 1, 1, "Clínica Sorriso Feliz", "(11)4444-5555" },
                    { 2, 2, "Clínica Odonto Vida Saudável", "(21)4444-5555" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(table: "Clinicas", keyColumn: "ClinicaId", keyValues: new object[] { 1 });
            migrationBuilder.DeleteData(table: "Dentistas", keyColumn: "DentistaId", keyValues: new object[] { 1 });
            migrationBuilder.DeleteData(table: "ContatosUsuarios", keyColumn: "ContatoUsuarioId", keyValues: new object[] { 1 });
            migrationBuilder.DeleteData(table: "Usuarios", keyColumn: "UsuarioId", keyValues: new object[] { 1 });
        }
    }
}
