﻿using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiChallenge.Models
{
    public class Dentista
    {
        public int DentistaId { get; set; }

        public int? UsuarioId { get; set; }

        public string? Nome { get; set; }

        public string? Especialidade { get; set; }

        public string? Telefone { get; set; }
        public string? Email { get; set; }

        // Relacionamentos
        public Usuario? Usuario { get; set; }
        public ICollection<Clinica>? Clinicas { get; set; }
        public ICollection<AtendimentoUsuario>? Atendimentos { get; set; }

        public Dentista()
        {
            Clinicas = new Collection<Clinica>();
            Atendimentos = new Collection<AtendimentoUsuario>();
        }
    }
}
