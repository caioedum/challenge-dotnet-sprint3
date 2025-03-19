using Oracle.ManagedDataAccess.Client;
using WebApiChallenge.Interfaces;
using WebApiChallenge.Models;

namespace WebApiChallenge.Repositories
{
    public class ContatoUsuarioRepository : IContatoUsuarioRepository
    {
        private readonly string _connectionString;

        public ContatoUsuarioRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("OracleConnection") ?? throw new ArgumentNullException(nameof(configuration), "Connection string cannot be null");
        }

        public List<ContatoUsuario> ObterTodos()
        {
            var contatos = new List<ContatoUsuario>();

            using (var connection = new OracleConnection(_connectionString))
            {
                connection.Open();

                using (var command = new OracleCommand("SELECT * FROM t_contato_usuario_odontoprev", connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            contatos.Add(new ContatoUsuario
                            {
                                ContatoUsuarioId = Convert.ToInt32(reader["contato_usuario_id"]),
                                UsuarioId = reader["usuario_id"] == DBNull.Value ? 0 : Convert.ToInt32(reader["usuario_id"]),
                                EmailUsuario = reader["email_usuario"].ToString(),
                                TelefoneUsuario = reader["telefone_usuario"].ToString()
                            });
                        }
                    }
                }
            }

            return contatos;
        }

        public ContatoUsuario? ObterPorId(int id)
        {
            ContatoUsuario? contato = null;

            using (var connection = new OracleConnection(_connectionString))
            {
                connection.Open();

                using (var command = new OracleCommand("SELECT * FROM t_contato_usuario_odontoprev WHERE contato_usuario_id = :id", connection))
                {
                    command.Parameters.Add(new OracleParameter("id", id));

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            contato = new ContatoUsuario
                            {
                                ContatoUsuarioId = Convert.ToInt32(reader["contato_usuario_id"]),
                                UsuarioId = reader["usuario_id"] == DBNull.Value ? 0 : Convert.ToInt32(reader["usuario_id"]),
                                EmailUsuario = reader["email_usuario"].ToString(),
                                TelefoneUsuario = reader["telefone_usuario"].ToString()
                            };
                        }
                    }
                }
            }

            return contato;
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

        public bool EmailJaCadastrado(string email)
        {
            using (var connection = new OracleConnection(_connectionString))
            {
                connection.Open();
                using (var command = new OracleCommand("SELECT COUNT(1) FROM t_contato_usuario_odontoprev WHERE email_usuario = :email", connection))
                {
                    command.Parameters.Add(new OracleParameter("email", email));
                    return Convert.ToInt32(command.ExecuteScalar()) > 0;
                }
            }
        }

        public bool TelefoneJaCadastrado(string telefone)
        {
            using (var connection = new OracleConnection(_connectionString))
            {
                connection.Open();
                using (var command = new OracleCommand("SELECT COUNT(1) FROM t_contato_usuario_odontoprev WHERE telefone_usuario = :telefone", connection))
                {
                    command.Parameters.Add(new OracleParameter("telefone", telefone));
                    return Convert.ToInt32(command.ExecuteScalar()) > 0;
                }
            }
        }

        public void AdicionarContato(ContatoUsuario contato)
        {
            using (var connection = new OracleConnection(_connectionString))
            {
                connection.Open();

                using (var command = new OracleCommand(
                    @"INSERT INTO t_contato_usuario_odontoprev 
                  (usuario_id, email_usuario, telefone_usuario) 
                  VALUES (:usuario_id, :email_usuario, :telefone_usuario)",
                    connection))
                {
                    command.Parameters.Add(new OracleParameter("usuario_id", contato.UsuarioId));
                    command.Parameters.Add(new OracleParameter("email_usuario", contato.EmailUsuario));
                    command.Parameters.Add(new OracleParameter("telefone_usuario", contato.TelefoneUsuario ?? (object)DBNull.Value));

                    command.ExecuteNonQuery();
                }
            }
        }
        public void AtualizarContato(ContatoUsuario contato)
        {
            using (var connection = new OracleConnection(_connectionString))
            {
                connection.Open();

                using (var command = new OracleCommand(
                    @"UPDATE t_contato_usuario_odontoprev 
                  SET usuario_id = :usuario_id, email_usuario = :email_usuario, telefone_usuario = :telefone_usuario 
                  WHERE contato_usuario_id = :contato_usuario_id",
                    connection))
                {
                    command.Parameters.Add(new OracleParameter("usuario_id", contato.UsuarioId));
                    command.Parameters.Add(new OracleParameter("email_usuario", contato.EmailUsuario));
                    command.Parameters.Add(new OracleParameter("telefone_usuario", contato.TelefoneUsuario ?? (object)DBNull.Value));
                    command.Parameters.Add(new OracleParameter("contato_usuario_id", contato.ContatoUsuarioId));

                    command.ExecuteNonQuery();
                }
            }
        }

        public void DeletarContato(int id)
        {
            using (var connection = new OracleConnection(_connectionString))
            {
                connection.Open();

                using (var command = new OracleCommand("DELETE FROM t_contato_usuario_odontoprev WHERE contato_usuario_id = :id", connection))
                {
                    command.Parameters.Add(new OracleParameter("id", id));
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
