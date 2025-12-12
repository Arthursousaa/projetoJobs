using System;
using System.Collections.Generic;

namespace projetoJobs.Models
{
    public class Candidato
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? Cpf { get; set; }           // mapeado como CPF no DbContext
        public DateTime? DataNascimento { get; set; }
        public string? Email { get; set; }
        public string? Senha { get; set; }
        public string? Telefone { get; set; }
        public string? Cidade { get; set; }
        public string? Estado { get; set; }
        public string? ResumoPerfil { get; set; }

        // Navegações
        public virtual ICollection<Curriculo> Curriculos { get; set; } = new List<Curriculo>();
        public virtual ICollection<Candidatura> Candidaturas { get; set; } = new List<Candidatura>();
    }
}
