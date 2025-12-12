using System;
using System.Collections.Generic;

namespace projetoJobs.Models
{
    public class Vaga
    {
        public int Id { get; set; }

        public string? NomeVaga { get; set; }
        public string? DescricaoVaga { get; set; }
        public string? Cidade { get; set; }
        public string? Estado { get; set; }
        public decimal? Salario { get; set; }
        public string? TipoContrato { get; set; }
        public string? NivelExperiencia { get; set; }

        // FK para Empresa (siga o mesmo nome usado no AppDbContext)
        public int EmpresasId { get; set; }
        public Empresa? Empresas { get; set; }

        // Navegações
        public virtual ICollection<Curriculo> Curriculos { get; set; } = new List<Curriculo>();
        public virtual ICollection<Candidatura> Candidaturas { get; set; } = new List<Candidatura>();
    }
}
