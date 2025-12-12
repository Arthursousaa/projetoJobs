using System;

namespace projetoJobs.Models.ViewModels
{
    public class CurriculoViewModel
    {
        public int CurriculoId { get; set; }
        public string? NomeArquivo { get; set; }
        public string? CaminhoArquivo { get; set; }
        public DateTime? DataEnvio { get; set; }

        public string? CandidatoNome { get; set; }
        public string? CandidatoEmail { get; set; }
        public string? Cidade { get; set; }
        public string? Estado { get; set; }
        public string? ResumoPerfil { get; set; }
    }
}
