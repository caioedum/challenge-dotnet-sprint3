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
            // Inserts para a classe Usuarios
            migrationBuilder.Sql(@"
                INSERT INTO Usuarios (Cpf, Nome, Sobrenome, DataNascimento, Genero, DataCadastro)
                VALUES ('12345678901', 'João', 'Silva', TO_DATE('1990-05-15', 'YYYY-MM-DD'), 'M', SYSDATE);
            ");

            migrationBuilder.Sql(@"
                INSERT INTO Usuarios (Cpf, Nome, Sobrenome, DataNascimento, Genero, DataCadastro)
                VALUES ('98765432100', 'Maria', 'Oliveira', TO_DATE('1985-10-20', 'YYYY-MM-DD'), 'F', SYSDATE);
            ");

            migrationBuilder.Sql(@"
                INSERT INTO Usuarios (Cpf, Nome, Sobrenome, DataNascimento, Genero, DataCadastro)
                VALUES ('45678912300', 'Carlos', 'Santos', TO_DATE('1978-03-12', 'YYYY-MM-DD'), 'M', SYSDATE);
            ");

            migrationBuilder.Sql(@"
                INSERT INTO Usuarios (Cpf, Nome, Sobrenome, DataNascimento, Genero, DataCadastro)
                VALUES ('32165498700', 'Ana', 'Souza', TO_DATE('1995-07-25', 'YYYY-MM-DD'), 'F', SYSDATE);
            ");

            migrationBuilder.Sql(@"
                INSERT INTO Usuarios (Cpf, Nome, Sobrenome, DataNascimento, Genero, DataCadastro)
                VALUES ('65498732100', 'Pedro', 'Lima', TO_DATE('2000-01-01', 'YYYY-MM-DD'), 'M', SYSDATE);
            ");

            // Inserts para a classe ContatosUsuarios
            migrationBuilder.Sql(@"
                INSERT INTO ContatosUsuarios (UsuarioId, Email, Telefone)
                VALUES (1, 'joao.silva@example.com', '(11) 98765-4321');
            ");

            migrationBuilder.Sql(@"
                INSERT INTO ContatosUsuarios (UsuarioId, Email, Telefone)
                VALUES (2, 'maria.oliveira@example.com', '(21) 91234-5678');
            ");

            migrationBuilder.Sql(@"
                INSERT INTO ContatosUsuarios (UsuarioId, Email, Telefone)
                VALUES (3, 'carlos.santos@example.com', '(31) 99876-5432');
            ");

            migrationBuilder.Sql(@"
                INSERT INTO ContatosUsuarios (UsuarioId, Email, Telefone)
                VALUES (4, 'ana.souza@example.com', '(41) 98765-4321');
            ");

            migrationBuilder.Sql(@"
                INSERT INTO ContatosUsuarios (UsuarioId, Email, Telefone)
                VALUES (5, 'pedro.lima@example.com', '(51) 91234-5678');
            ");

            // Inserts para a classe Dentistas
            migrationBuilder.Sql(@"
                INSERT INTO Dentistas (UsuarioId, Nome, Especialidade, Telefone, Email)
                VALUES (1, 'Dr. João Silva', 'Ortodontia', '(11) 98765-4321', 'joao.silva@dentista.com');
            ");

            migrationBuilder.Sql(@"
                INSERT INTO Dentistas (UsuarioId, Nome, Especialidade, Telefone, Email)
                VALUES (2, 'Dra. Maria Oliveira', 'Endodontia', '(21) 91234-5678', 'maria.oliveira@dentista.com');
            ");

            migrationBuilder.Sql(@"
                INSERT INTO Dentistas (UsuarioId, Nome, Especialidade, Telefone, Email)
                VALUES (3, 'Dr. Carlos Santos', 'Implantodontia', '(31) 99876-5432', 'carlos.santos@dentista.com');
            ");

            migrationBuilder.Sql(@"
                INSERT INTO Dentistas (UsuarioId, Nome, Especialidade, Telefone, Email)
                VALUES (4, 'Dra. Ana Souza', 'Periodontia', '(41) 98765-4321', 'ana.souza@dentista.com');
            ");

            migrationBuilder.Sql(@"
                INSERT INTO Dentistas (UsuarioId, Nome, Especialidade, Telefone, Email)
                VALUES (5, 'Dr. Pedro Lima', 'Prótese Dentária', '(51) 91234-5678', 'pedro.lima@dentista.com');
            ");

            // Inserts para a classe Clinicas
            migrationBuilder.Sql(@"
                INSERT INTO Clinicas (DentistaId, Nome, Telefone)
                VALUES (1, 'Clínica Odonto Saúde', '(11) 98765-4321');
            ");

            migrationBuilder.Sql(@"
                INSERT INTO Clinicas (DentistaId, Nome, Telefone)
                VALUES (2, 'Clínica Sorriso Feliz', '(21) 91234-5678');
            ");

            migrationBuilder.Sql(@"
                INSERT INTO Clinicas (DentistaId, Nome, Telefone)
                VALUES (3, 'Clínica Dental Care', '(31) 99876-5432');
            ");

            migrationBuilder.Sql(@"
                INSERT INTO Clinicas (DentistaId, Nome, Telefone)
                VALUES (4, 'Clínica Bem Estar', '(41) 98765-4321');
            ");

            migrationBuilder.Sql(@"
                INSERT INTO Clinicas (DentistaId, Nome, Telefone)
                VALUES (5, 'Clínica Vida Dental', '(51) 91234-5678');
            ");


            // Inserts para a classe EnderecosUsuarios
            migrationBuilder.Sql(@"
                INSERT INTO EnderecosUsuarios (UsuarioId, Cep, Cidade, Estado, Logradouro, Bairro)
                VALUES (1, '12345-678', 'São Paulo', 'SP', 'Rua das Flores', 'Jardim Primavera');
            ");

            migrationBuilder.Sql(@"
                INSERT INTO EnderecosUsuarios (UsuarioId, Cep, Cidade, Estado, Logradouro, Bairro)
                VALUES (2, '98765-432', 'Rio de Janeiro', 'RJ', 'Avenida Atlântica', 'Copacabana');
            ");

            migrationBuilder.Sql(@"
                INSERT INTO EnderecosUsuarios (UsuarioId, Cep, Cidade, Estado, Logradouro, Bairro)
                VALUES (3, '45678-123', 'Belo Horizonte', 'MG', 'Rua da Harmonia', 'Savassi');
            ");

            migrationBuilder.Sql(@"
                INSERT INTO EnderecosUsuarios (UsuarioId, Cep, Cidade, Estado, Logradouro, Bairro)
                VALUES (4, '32165-987', 'Curitiba', 'PR', 'Rua XV de Novembro', 'Centro');
            ");

            migrationBuilder.Sql(@"
                INSERT INTO EnderecosUsuarios (UsuarioId, Cep, Cidade, Estado, Logradouro, Bairro)
                VALUES (5, '65498-321', 'Porto Alegre', 'RS', 'Avenida Ipiranga', 'Partenon');
            ");

            // Inserts para a classe ImagensUsuarios
            migrationBuilder.Sql(@"
                INSERT INTO ImagensUsuarios (UsuarioId, ImagemUrl, DataEnvio)
                VALUES (1, 'https://example.com/imagens/usuario1.jpg', SYSDATE);
            ");

            migrationBuilder.Sql(@"
                INSERT INTO ImagensUsuarios (UsuarioId, ImagemUrl, DataEnvio)
                VALUES (2, 'https://example.com/imagens/usuario2.jpg', SYSDATE);
            ");

            migrationBuilder.Sql(@"
                INSERT INTO ImagensUsuarios (UsuarioId, ImagemUrl, DataEnvio)
                VALUES (3, 'https://example.com/imagens/usuario3.jpg', SYSDATE);
            ");

            migrationBuilder.Sql(@"
                INSERT INTO ImagensUsuarios (UsuarioId, ImagemUrl, DataEnvio)
                VALUES (4, 'https://example.com/imagens/usuario4.jpg', SYSDATE);
            ");

            migrationBuilder.Sql(@"
                INSERT INTO ImagensUsuarios (UsuarioId, ImagemUrl, DataEnvio)
                VALUES (5, 'https://example.com/imagens/usuario5.jpg', SYSDATE);
            ");

            
            // Inserts para a classe PrevisoesUsuarios
            migrationBuilder.Sql(@"
                INSERT INTO PrevisoesUsuarios (ImagemUsuarioId, UsuarioId, PrevisaoTexto, Probabilidade, Recomendacao, DataPrevisao)
                VALUES (1, 1, 'Cárie detectada', 85.50, 'Agendar consulta com dentista', SYSDATE);
            ");

            migrationBuilder.Sql(@"
                INSERT INTO PrevisoesUsuarios (ImagemUsuarioId, UsuarioId, PrevisaoTexto, Probabilidade, Recomendacao, DataPrevisao)
                VALUES (2, 2, 'Gengivite leve', 70.20, 'Usar enxaguante bucal e consultar dentista', SYSDATE);
            ");

            migrationBuilder.Sql(@"
                INSERT INTO PrevisoesUsuarios (ImagemUsuarioId, UsuarioId, PrevisaoTexto, Probabilidade, Recomendacao, DataPrevisao)
                VALUES (3, 3, 'Sem problemas detectados', 99.90, 'Manter higiene bucal diária', SYSDATE);
            ");

            migrationBuilder.Sql(@"
                INSERT INTO PrevisoesUsuarios (ImagemUsuarioId, UsuarioId, PrevisaoTexto, Probabilidade, Recomendacao, DataPrevisao)
                VALUES (4, 4, 'Placa bacteriana moderada', 60.00, 'Realizar limpeza profissional', SYSDATE);
            ");

            migrationBuilder.Sql(@"
                INSERT INTO PrevisoesUsuarios (ImagemUsuarioId, UsuarioId, PrevisaoTexto, Probabilidade, Recomendacao, DataPrevisao)
                VALUES (5, 5, 'Cárie avançada', 95.80, 'Agendar tratamento urgente com dentista', SYSDATE);
            ");

            // Inserts para classe AtendimentosUsuarios
            migrationBuilder.Sql(@"
                INSERT INTO AtendimentosUsuarios (UsuarioId, DentistaId, ClinicaId, DataAtendimento, DescricaoProcedimento, Custo, DataRegistro)
                VALUES (1, 1, 1, TO_DATE('2025-03-01', 'YYYY-MM-DD'), 'Limpeza dental completa', 150.00, SYSDATE);
            ");

            migrationBuilder.Sql(@"
                INSERT INTO AtendimentosUsuarios (UsuarioId, DentistaId, ClinicaId, DataAtendimento, DescricaoProcedimento, Custo, DataRegistro)
                VALUES (2, 2, 2, TO_DATE('2025-02-15', 'YYYY-MM-DD'), 'Tratamento de cárie', 200.00, SYSDATE);
            ");

            migrationBuilder.Sql(@"
                INSERT INTO AtendimentosUsuarios (UsuarioId, DentistaId, ClinicaId, DataAtendimento, DescricaoProcedimento, Custo, DataRegistro)
                VALUES (3, 3, 3, TO_DATE('2025-01-20', 'YYYY-MM-DD'), 'Implante dentário', 2500.00, SYSDATE);
            ");

            migrationBuilder.Sql(@"
                INSERT INTO AtendimentosUsuarios (UsuarioId, DentistaId, ClinicaId, DataAtendimento, DescricaoProcedimento, Custo, DataRegistro)
                VALUES (4, 4, 4, TO_DATE('2025-03-10', 'YYYY-MM-DD'), 'Clareamento dental', 500.00, SYSDATE);
            ");

            migrationBuilder.Sql(@"
                INSERT INTO AtendimentosUsuarios (UsuarioId, DentistaId, ClinicaId, DataAtendimento, DescricaoProcedimento, Custo, DataRegistro)
                VALUES (5, 5, 5, TO_DATE('2025-02-05', 'YYYY-MM-DD'), 'Extração de dente', 300.00, SYSDATE);
            ");

            // Inserts para classe EnderecosClinicas
            migrationBuilder.Sql(@"
                INSERT INTO EnderecosClinicas (ClinicaId, Cep, Cidade, Estado, Logradouro, Bairro)
                VALUES (1, '12345-678', 'São Paulo', 'SP', 'Rua das Flores', 'Jardim Primavera');
            ");

            migrationBuilder.Sql(@"
                INSERT INTO EnderecosClinicas (ClinicaId, Cep, Cidade, Estado, Logradouro, Bairro)
                VALUES (2, '98765-432', 'Rio de Janeiro', 'RJ', 'Avenida Atlântica', 'Copacabana');
            ");

            migrationBuilder.Sql(@"
                INSERT INTO EnderecosClinicas (ClinicaId, Cep, Cidade, Estado, Logradouro, Bairro)
                VALUES (3, '45678-123', 'Belo Horizonte', 'MG', 'Rua da Harmonia', 'Savassi');
            ");

            migrationBuilder.Sql(@"
                INSERT INTO EnderecosClinicas (ClinicaId, Cep, Cidade, Estado, Logradouro, Bairro)
                VALUES (4, '32165-987', 'Curitiba', 'PR', 'Rua XV de Novembro', 'Centro');
            ");

            migrationBuilder.Sql(@"
                INSERT INTO EnderecosClinicas (ClinicaId, Cep, Cidade, Estado, Logradouro, Bairro)
                VALUES (5, '65498-321', 'Porto Alegre', 'RS', 'Avenida Ipiranga', 'Partenon');
            ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM EnderecosClinicas WHERE ClinicaId IN (1, 2, 3, 4, 5);");

            // Excluir dados da tabela AtendimentosUsuarios
            migrationBuilder.Sql("DELETE FROM AtendimentosUsuarios WHERE UsuarioId IN (1, 2, 3, 4, 5);");

            // Excluir dados da tabela PrevisoesUsuarios
            migrationBuilder.Sql("DELETE FROM PrevisoesUsuarios WHERE UsuarioId IN (1, 2, 3, 4, 5);");

            // Delete para a classe ImagensUsuarios
            migrationBuilder.Sql("DELETE FROM ImagensUsuarios WHERE UsuarioId IN (1, 2, 3, 4, 5);");

            // Delete para a classe EnderecosUsuarios
            migrationBuilder.Sql("DELETE FROM EnderecosUsuarios WHERE UsuarioId IN (1, 2, 3, 4, 5);");

            // Delete para a classe Dentistas
            migrationBuilder.Sql("DELETE FROM Clinicas WHERE DentistaId IN (1, 2, 3, 4, 5);");

            // Delete para a classe ContatosUsuarios
            migrationBuilder.Sql("DELETE FROM ContatosUsuarios WHERE UsuarioId IN (1, 2, 3, 4, 5);");

            // Delete para a classe Usuarios
            migrationBuilder.Sql("DELETE FROM Usuarios WHERE Cpf IN ('12345678901', '98765432100', '45678912300', '32165498700', '65498732100');");
        }
    }
}
