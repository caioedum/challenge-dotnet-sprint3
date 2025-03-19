using System;
using System.Collections.Generic;
using System.Data;
using Oracle.ManagedDataAccess.Client;
using WebApiChallenge.Interfaces;
using WebApiChallenge.Models;

namespace WebApiChallenge.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly string _connectionString;

        public UsuarioRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("OracleConnection") ?? throw new ArgumentNullException(nameof(configuration), "Connection string cannot be null");
        }

        public List<Usuario> ObterTodos()
        {
            var usuarios = new List<Usuario>();

            using (var connection = new OracleConnection(_connectionString))
            {
                connection.Open();

                using (var command = new OracleCommand("SELECT * FROM t_usuario_odontoprev", connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            usuarios.Add(new Usuario
                            {
                                UsuarioId = Convert.ToInt32(reader["usuario_id"]),
                                Cpf = reader["cpf"]?.ToString(),
                                Nome = reader["nome"]?.ToString(),
                                Sobrenome = reader["sobrenome"]?.ToString(),
                                DataNascimento = reader["data_nascimento"] == DBNull.Value ? null : Convert.ToDateTime(reader["data_nascimento"]),
                                Genero = reader["genero"]?.ToString(),
                                DataCadastro = Convert.ToDateTime(reader["data_cadastro"])
                            });
                        }
                    }
                }
            }

            return usuarios;
        }

        public Usuario? ObterPorId(int usuarioId)
        {
            Usuario? usuario = null;

            using (var connection = new OracleConnection(_connectionString))
            {
                connection.Open();

                using (var command = new OracleCommand("SELECT * FROM t_usuario_odontoprev WHERE usuario_id = :usuario_id", connection))
                {
                    command.Parameters.Add(new OracleParameter("usuario_id", usuarioId));

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            usuario = new Usuario
                            {
                                UsuarioId = Convert.ToInt32(reader["usuario_id"]),
                                Cpf = reader["cpf"]?.ToString(),
                                Nome = reader["nome"]?.ToString(),
                                Sobrenome = reader["sobrenome"]?.ToString(),
                                DataNascimento = reader["data_nascimento"] == DBNull.Value ? null : Convert.ToDateTime(reader["data_nascimento"]),
                                Genero = reader["genero"]?.ToString(),
                                DataCadastro = Convert.ToDateTime(reader["data_cadastro"])
                            };
                        }
                    }
                }
            }

            return usuario;
        }

        public void AdicionarUsuario(Usuario usuario)
        {
            using (var connection = new OracleConnection(_connectionString))
            {
                connection.Open();

                using (var command = new OracleCommand(
                    @"INSERT INTO t_usuario_odontoprev 
                  (cpf, nome, sobrenome, data_nascimento, genero, data_cadastro) 
                  VALUES (:cpf, :nome, :sobrenome, :data_nascimento, :genero, :data_cadastro)",
                    connection))
                {
                    command.Parameters.Add(new OracleParameter("cpf", usuario.Cpf));
                    command.Parameters.Add(new OracleParameter("nome", usuario.Nome));
                    command.Parameters.Add(new OracleParameter("sobrenome", usuario.Sobrenome));
                    command.Parameters.Add(new OracleParameter("data_nascimento", usuario.DataNascimento ?? (object)DBNull.Value));
                    command.Parameters.Add(new OracleParameter("genero", usuario.Genero));
                    command.Parameters.Add(new OracleParameter("data_cadastro", usuario.DataCadastro ?? DateTime.Now));

                    command.ExecuteNonQuery();
                }
            }
        }

        public void AtualizarUsuario(Usuario usuario)
        {
            using (var connection = new OracleConnection(_connectionString))
            {
                connection.Open();

                using (var command = new OracleCommand(
                    @"UPDATE t_usuario_odontoprev 
                  SET cpf = :cpf, nome = :nome, sobrenome = :sobrenome, 
                      data_nascimento = :data_nascimento, genero = :genero 
                  WHERE usuario_id = :usuario_id",
                    connection))
                {
                    command.Parameters.Add(new OracleParameter("cpf", usuario.Cpf));
                    command.Parameters.Add(new OracleParameter("nome", usuario.Nome));
                    command.Parameters.Add(new OracleParameter("sobrenome", usuario.Sobrenome));
                    command.Parameters.Add(new OracleParameter("data_nascimento", usuario.DataNascimento ?? (object)DBNull.Value));
                    command.Parameters.Add(new OracleParameter("genero", usuario.Genero));
                    command.Parameters.Add(new OracleParameter("usuario_id", usuario.UsuarioId));
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
