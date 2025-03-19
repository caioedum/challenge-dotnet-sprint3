using System;
using System.Collections.Generic;
using System.Data;
using Oracle.ManagedDataAccess.Client;
using WebApiChallenge.Interfaces;
using WebApiChallenge.Models;

public class DentistaRepository : IDentistaRepository
{
    private readonly string _connectionString;

    public DentistaRepository(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("OracleConnection") ?? throw new ArgumentNullException(nameof(configuration), "Connection string cannot be null");
    }

    public List<Dentista> ObterTodos()
    {
        var dentistas = new List<Dentista>();

        using (var connection = new OracleConnection(_connectionString))
        {
            connection.Open();

            using (var command = new OracleCommand("SELECT * FROM t_dentista_odontoprev", connection))
            {
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        dentistas.Add(new Dentista
                        {
                            DentistaId = Convert.ToInt32(reader["dentista_id"]),
                            UsuarioId = reader["usuario_id"] == DBNull.Value ? 0 : Convert.ToInt32(reader["usuario_id"]),
                            NomeDentista = reader["nome_dentista"].ToString(),
                            Especialidade = reader["especialidade"].ToString(),
                            TelefoneDentista = reader["telefone_dentista"].ToString(),
                            EmailDentista = reader["email_dentista"].ToString()
                        });
                    }
                }
            }
        }

        return dentistas;
    }

    public Dentista? ObterPorId(int dentistaId)
    {
        Dentista? dentista = null;

        using (var connection = new OracleConnection(_connectionString))
        {
            connection.Open();

            using (var command = new OracleCommand("SELECT * FROM t_dentista_odontoprev WHERE dentista_id = :id", connection))
            {
                command.Parameters.Add(new OracleParameter("id", dentistaId));

                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        dentista = new Dentista
                        {
                            DentistaId = Convert.ToInt32(reader["dentista_id"]),
                            UsuarioId = reader["usuario_id"] == DBNull.Value ? 0 : Convert.ToInt32(reader["usuario_id"]),
                            NomeDentista = reader["nome_dentista"].ToString(),
                            Especialidade = reader["especialidade"].ToString(),
                            TelefoneDentista = reader["telefone_dentista"].ToString(),
                            EmailDentista = reader["email_dentista"].ToString()
                        };
                    }
                }
            }
        }

        return dentista;
    }

    public void AdicionarDentista(Dentista dentista)
    {
        using (var connection = new OracleConnection(_connectionString))
        {
            connection.Open();

            using (var command = new OracleCommand(
                @"INSERT INTO t_dentista_odontoprev 
                  (usuario_id, nome_dentista, especialidade, telefone_dentista, email_dentista) 
                  VALUES (:usuario_id, :nome_dentista, :especialidade, :telefone_dentista, :email_dentista)",
                connection))
            {
                command.Parameters.Add(new OracleParameter("usuario_id", dentista.UsuarioId));
                command.Parameters.Add(new OracleParameter("nome_dentista", dentista.NomeDentista));
                command.Parameters.Add(new OracleParameter("especialidade", dentista.Especialidade ?? (object)DBNull.Value));
                command.Parameters.Add(new OracleParameter("telefone_dentista", dentista.TelefoneDentista ?? (object)DBNull.Value));
                command.Parameters.Add(new OracleParameter("email_dentista", dentista.EmailDentista ?? (object)DBNull.Value));

                command.ExecuteNonQuery();
            }
        }
    }

    public void AtualizarDentista(Dentista dentista)
    {
        using (var connection = new OracleConnection(_connectionString))
        {
            connection.Open();

            using (var command = new OracleCommand(
                @"UPDATE t_dentista_odontoprev 
                  SET usuario_id = :usuario_id, nome_dentista = :nome_dentista, especialidade = :especialidade, 
                      telefone_dentista = :telefone_dentista, email_dentista = :email_dentista 
                  WHERE dentista_id = :dentista_id",
                connection))
            {
                command.Parameters.Add(new OracleParameter("usuario_id", dentista.UsuarioId));
                command.Parameters.Add(new OracleParameter("nome_dentista", dentista.NomeDentista));
                command.Parameters.Add(new OracleParameter("especialidade", dentista.Especialidade ?? (object)DBNull.Value));
                command.Parameters.Add(new OracleParameter("telefone_dentista", dentista.TelefoneDentista ?? (object)DBNull.Value));
                command.Parameters.Add(new OracleParameter("email_dentista", dentista.EmailDentista ?? (object)DBNull.Value));
                command.Parameters.Add(new OracleParameter("dentista_id", dentista.DentistaId));

                command.ExecuteNonQuery();
            }
        }
    }
}
