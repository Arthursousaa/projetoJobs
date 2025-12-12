using System;

namespace projetoJobs.Models
{
    public class Candidatura
    {
        public int Id { get; set; }

        public int CandidatoId { get; set; }
        public Candidato? Candidato { get; set; }

        public int VagaId { get; set; }
        public Vaga? Vaga { get; set; }

        public DateTime DataCandidatura { get; set; } = DateTime.Now;
    }
}
