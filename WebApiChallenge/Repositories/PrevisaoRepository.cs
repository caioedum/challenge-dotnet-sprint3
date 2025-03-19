using Oracle.ManagedDataAccess.Client;
using WebApiChallenge.Interfaces;
using WebApiChallenge.Models;

namespace WebApiChallenge.Repositories
{
    public class PrevisaoRepository : IPrevisaoRepository
    {
        private readonly string _connectionString;

        public PrevisaoRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("OracleConnection") ?? throw new ArgumentNullException(nameof(configuration), "Connection string cannot be null");
        }

        public List<Previsao> ObterTodos()
        {
            var previsoes = new List<Previsao>();

            using var connection = new OracleConnection(_connectionString);
            connection.Open();

            using var command = new OracleCommand("SELECT * FROM t_previsao_usuario_odontoprev", connection);
            using var reader = command.ExecuteReader();

            while (reader.Read())
            {
                previsoes.Add(new Previsao
                {
                    PrevisaoId = Convert.ToInt32(reader["previsao_usuario_id"]),
                    ImagemId = reader["imagem_usuario_id"] == DBNull.Value ? null : Convert.ToInt32(reader["imagem_usuario_id"]),
                    UsuarioId = reader["usuario_id"] == DBNull.Value ? null : Convert.ToInt32(reader["usuario_id"]),
                    PrevisaoTexto = reader["previsao_texto"].ToString(),
                    Probabilidade = reader["probabilidade"] == DBNull.Value ? null : Convert.ToSingle(reader["probabilidade"]),
                    Recomendacao = reader["recomendacao"].ToString(),
                    DataPrevisao = Convert.ToDateTime(reader["data_previsao"])
                });
            }

            return previsoes;
        }

        public Previsao? ObterPorId(int id)
        {
            using var connection = new OracleConnection(_connectionString);
            connection.Open();

            using var command = new OracleCommand("SELECT * FROM t_previsao_usuario_odontoprev WHERE previsao_usuario_id = :id", connection);
            command.Parameters.Add(new OracleParameter("id", id));

            using var reader = command.ExecuteReader();
            if (reader.Read())
            {
                return new Previsao
                {
                    PrevisaoId = Convert.ToInt32(reader["previsao_usuario_id"]),
                    ImagemId = reader["imagem_usuario_id"] == DBNull.Value ? null : Convert.ToInt32(reader["imagem_usuario_id"]),
                    UsuarioId = reader["usuario_id"] == DBNull.Value ? null : Convert.ToInt32(reader["usuario_id"]),
                    PrevisaoTexto = reader["previsao_texto"].ToString(),
                    Probabilidade = reader["probabilidade"] == DBNull.Value ? null : Convert.ToSingle(reader["probabilidade"]),
                    Recomendacao = reader["recomendacao"].ToString(),
                    DataPrevisao = Convert.ToDateTime(reader["data_previsao"])
                };
            }

            return null;
        }
        public bool VerificarImagemPorId(int imagemId)
        {
            using (var connection = new OracleConnection(_connectionString))
            {
                connection.Open();

                using (var command = new OracleCommand("SELECT COUNT(1) FROM t_imagem_usuario_odontoprev WHERE imagem_usuario_id = :id", connection))
                {
                    command.Parameters.Add(new OracleParameter("id", imagemId));
                    return Convert.ToInt32(command.ExecuteScalar()) > 0;
                }
            }
        }

        public bool VerificarUsuarioPorId(int usuarioId)
        {
            using (var connection = new OracleConnection(_connectionString))
            {
                connection.Open();

                using (var command = new OracleCommand("SELECT COUNT(1) FROM t_usuario_odontoprev WHERE usuario_id = :id", connection))
                {
                    command.Parameters.Add(new OracleParameter("id", usuarioId));
                    return Convert.ToInt32(command.ExecuteScalar()) > 0;
                }
            }
        }

        public void AdicionarPrevisao(Previsao previsao)
        {
            using var connection = new OracleConnection(_connectionString);
            connection.Open();

            using var command = new OracleCommand(@"
            INSERT INTO t_previsao_usuario_odontoprev 
              (imagem_usuario_id, usuario_id, previsao_texto, probabilidade, recomendacao) 
            VALUES (:imagem_usuario_id, :usuario_id, :previsao_texto, :probabilidade, :recomendacao)
            RETURNING previsao_usuario_id INTO :id", connection);

            command.Parameters.Add(new OracleParameter("imagem_usuario_id", previsao.ImagemId));
            command.Parameters.Add(new OracleParameter("usuario_id", previsao.UsuarioId));
            command.Parameters.Add(new OracleParameter("previsao_texto", previsao.PrevisaoTexto ?? (object)DBNull.Value));
            command.Parameters.Add(new OracleParameter("probabilidade", previsao.Probabilidade));
            command.Parameters.Add(new OracleParameter("recomendacao", previsao.Recomendacao ?? (object)DBNull.Value));

            var idParam = new OracleParameter("id", OracleDbType.Int32) { Direction = System.Data.ParameterDirection.Output };
            command.Parameters.Add(idParam);

            command.ExecuteNonQuery();
        }

        public void AtualizarPrevisao(Previsao previsao)
        {
            using var connection = new OracleConnection(_connectionString);
            connection.Open();

            using var command = new OracleCommand(@"
            UPDATE t_previsao_usuario_odontoprev SET 
              imagem_usuario_id = :imagem_usuario_id,
              usuario_id = :usuario_id,
              previsao_texto = :previsao_texto,
              probabilidade = :probabilidade,
              recomendacao = :recomendacao
            WHERE previsao_usuario_id = :id", connection);

            command.Parameters.Add(new OracleParameter("imagem_usuario_id", previsao.ImagemId.HasValue ? (object)previsao.ImagemId.Value : DBNull.Value));
            command.Parameters.Add(new OracleParameter("usuario_id", previsao.UsuarioId.HasValue ? (object)previsao.UsuarioId.Value : DBNull.Value));
            command.Parameters.Add(new OracleParameter("previsao_texto", previsao.PrevisaoTexto));
            command.Parameters.Add(new OracleParameter("probabilidade", previsao.Probabilidade.HasValue ? (object)previsao.Probabilidade.Value : DBNull.Value));
            command.Parameters.Add(new OracleParameter("recomendacao", previsao.Recomendacao));
            command.Parameters.Add(new OracleParameter("id", previsao.PrevisaoId));

            command.ExecuteNonQuery();
        }

        public void DeletarPrevisao(int id)
        {
            using var connection = new OracleConnection(_connectionString);
            connection.Open();

            using var command = new OracleCommand("DELETE FROM t_previsao_usuario_odontoprev WHERE previsao_usuario_id = :id", connection);

            command.Parameters.Add(new OracleParameter("id", id));

            command.ExecuteNonQuery();
        }
    }
}
