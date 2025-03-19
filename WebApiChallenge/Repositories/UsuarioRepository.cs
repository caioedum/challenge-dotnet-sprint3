using System;
using System.Collections.Generic;
using System.Data;
using Oracle.ManagedDataAccess.Client;
using WebApiChallenge.Models;

namespace WebApiChallenge.Repositories
{
    public class UsuarioRepository
    {
        private readonly string _connectionString;

        public UsuarioRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("OracleConnection");
        }

        // Método para buscar todos os usuários
        public List<Usuario> GetAll()
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

        // Método para buscar um usuário por ID
        public Usuario GetById(int usuarioId)
        {
            Usuario usuario = null;

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

        // Método para adicionar um novo usuário
        public void Add(Usuario usuario)
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

        // Método para atualizar um usuário existente
        public void Update(Usuario usuario)
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

        // Método para excluir um usuário por ID
        public void Delete(int usuarioId)
        {
            using (var connection = new OracleConnection(_connectionString))
            {
                connection.Open();

                using (var command = new OracleCommand("DELETE FROM t_usuario_odontoprev WHERE usuario_id = :usuario_id", connection))
                {
                    command.Parameters.Add(new OracleParameter("usuario_id", usuarioId));

                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
