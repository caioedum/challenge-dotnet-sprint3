using Oracle.ManagedDataAccess.Client;
using WebApiChallenge.Interfaces;
using WebApiChallenge.Models;

namespace WebApiChallenge.Repositories
{
    public class AtendimentoUsuarioRepository : IAtendimentoUsuarioRepository
    {
        private readonly string _connectionString;

        public AtendimentoUsuarioRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("OracleConnection") ?? throw new ArgumentNullException(nameof(configuration), "Connection string cannot be null");
        }

        public List<AtendimentoUsuario> ObterTodos()
        {
            var atendimentos = new List<AtendimentoUsuario>();

            using (var connection = new OracleConnection(_connectionString))
            {
                connection.Open();

                using (var command = new OracleCommand("SELECT * FROM t_atendimento_usuario_odontoprev", connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            atendimentos.Add(new AtendimentoUsuario
                            {
                                AtendimentoUsuarioId = Convert.ToInt32(reader["atendimento_id"]),
                                UsuarioId = reader["usuario_id"] == DBNull.Value ? 0 : Convert.ToInt32(reader["usuario_id"]),
                                DentistaId = reader["dentista_id"] == DBNull.Value ? 0 : Convert.ToInt32(reader["dentista_id"]),
                                ClinicaId = reader["clinica_id"] == DBNull.Value ? 0 : Convert.ToInt32(reader["clinica_id"]),
                                DataAtendimento = reader["data_atendimento"] == DBNull.Value ? null : Convert.ToDateTime(reader["data_atendimento"]),
                                DescricaoProcedimento = reader["descricao_procedimento"].ToString(),
                                Custo = reader["custo"] == DBNull.Value ? null : Convert.ToDecimal(reader["custo"]),
                                DataRegistro = Convert.ToDateTime(reader["data_registro"])
                            });
                        }
                    }
                }
            }

            return atendimentos;
        }

        public AtendimentoUsuario? ObterPorId(int atendimentoId)
        {
            AtendimentoUsuario? atendimento = null;

            using (var connection = new OracleConnection(_connectionString))
            {
                connection.Open();

                using (var command = new OracleCommand("SELECT * FROM t_atendimento_usuario_odontoprev WHERE atendimento_id = :id", connection))
                {
                    command.Parameters.Add(new OracleParameter("id", atendimentoId));

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            atendimento = new AtendimentoUsuario
                            {
                                AtendimentoUsuarioId = Convert.ToInt32(reader["atendimento_id"]),
                                UsuarioId = reader["usuario_id"] == DBNull.Value ? 0 : Convert.ToInt32(reader["usuario_id"]),
                                DentistaId = reader["dentista_id"] == DBNull.Value ? 0 : Convert.ToInt32(reader["dentista_id"]),
                                ClinicaId = reader["clinica_id"] == DBNull.Value ? 0 : Convert.ToInt32(reader["clinica_id"]),
                                DataAtendimento = reader["data_atendimento"] == DBNull.Value ? null : Convert.ToDateTime(reader["data_atendimento"]),
                                DescricaoProcedimento = reader["descricao_procedimento"].ToString(),
                                Custo = reader["custo"] == DBNull.Value ? null : Convert.ToDecimal(reader["custo"]),
                                DataRegistro = Convert.ToDateTime(reader["data_registro"])
                            };
                        }
                    }
                }
            }

            return atendimento;
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

        public bool VerificarDentistaPorId(int dentistaId)
        {
            using (var connection = new OracleConnection(_connectionString))
            {
                connection.Open();

                using (var command = new OracleCommand("SELECT COUNT(1) FROM t_dentista_odontoprev WHERE dentista_id = :id", connection))
                {
                    command.Parameters.Add(new OracleParameter("id", dentistaId));
                    return Convert.ToInt32(command.ExecuteScalar()) > 0;
                }
            }
        }

        public bool VerificarClinicaPorId(int clinicaId)
        {
            using (var connection = new OracleConnection(_connectionString))
            {
                connection.Open();

                using (var command = new OracleCommand("SELECT COUNT(1) FROM t_clinica_odontoprev WHERE clinica_id = :id", connection))
                {
                    command.Parameters.Add(new OracleParameter("id", clinicaId));
                    return Convert.ToInt32(command.ExecuteScalar()) > 0;
                }
            }
        }

        public void AdicionarAtendimento(AtendimentoUsuario atendimento)
        {
            using (var connection = new OracleConnection(_connectionString))
            {
                connection.Open();

                using (var command = new OracleCommand(
                    @"INSERT INTO t_atendimento_usuario_odontoprev 
                  (usuario_id, dentista_id, clinica_id, data_atendimento, descricao_procedimento, custo) 
                  VALUES (:usuario_id, :dentista_id, :clinica_id, :data_atendimento, :descricao_procedimento, :custo)",
                    connection))
                {
                    command.Parameters.Add(new OracleParameter("usuario_id", atendimento.UsuarioId));
                    command.Parameters.Add(new OracleParameter("dentista_id", atendimento.DentistaId));
                    command.Parameters.Add(new OracleParameter("clinica_id", atendimento.ClinicaId));
                    command.Parameters.Add(new OracleParameter("data_atendimento", atendimento.DataAtendimento ?? (object)DBNull.Value));
                    command.Parameters.Add(new OracleParameter("descricao_procedimento", atendimento.DescricaoProcedimento ?? (object)DBNull.Value));
                    command.Parameters.Add(new OracleParameter("custo", atendimento.Custo ?? (object)DBNull.Value));

                    command.ExecuteNonQuery();
                }
            }
        }

        public void AtualizarAtendimento(AtendimentoUsuario atendimento)
        {
            using (var connection = new OracleConnection(_connectionString))
            {
                connection.Open();

                using (var command = new OracleCommand(
                    @"UPDATE t_atendimento_usuario_odontoprev 
                  SET usuario_id = :usuario_id, dentista_id = :dentista_id, clinica_id = :clinica_id,
                      data_atendimento = :data_atendimento, descricao_procedimento = :descricao_procedimento, custo = :custo 
                  WHERE atendimento_id = :atendimento_id",
                    connection))
                {
                    command.Parameters.Add(new OracleParameter("usuario_id", atendimento.UsuarioId));
                    command.Parameters.Add(new OracleParameter("dentista_id", atendimento.DentistaId));
                    command.Parameters.Add(new OracleParameter("clinica_id", atendimento.ClinicaId));
                    command.Parameters.Add(new OracleParameter("data_atendimento", atendimento.DataAtendimento ?? (object)DBNull.Value));
                    command.Parameters.Add(new OracleParameter("descricao_procedimento", atendimento.DescricaoProcedimento ?? (object)DBNull.Value));
                    command.Parameters.Add(new OracleParameter("custo", atendimento.Custo ?? (object)DBNull.Value));
                    command.Parameters.Add(new OracleParameter("atendimento_id", atendimento.AtendimentoUsuarioId));

                    command.ExecuteNonQuery();
                }
            }
        }

        public void DeletarAtendimento(int id)
        {
            using (var connection = new OracleConnection(_connectionString))
            {
                connection.Open();

                using (var command = new OracleCommand("DELETE FROM t_atendimento_usuario_odontoprev WHERE atendimento_id = :id", connection))
                {
                    command.Parameters.Add(new OracleParameter("id", id));
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
