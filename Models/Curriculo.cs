using System;

namespace projetoJobs.Models
{
    public class Curriculo
    {
        public int Id { get; set; }
        public string? NomeArquivo { get; set; }
        public string? CaminhoArquivo { get; set; }
        public DateTime? DataEnvio { get; set; }

        public int CandidatosId { get; set; }
        public Candidato? Candidato { get; set; }

        public int VagasId { get; set; }
        public Vaga? Vaga { get; set; }
    }
}
