using System;
using System.Collections.Generic;

namespace projetoJobs.Models;

public partial class Curriculo
{
    public int Id { get; set; }

    public string? NomeArquivo { get; set; }

    public string? CaminhoArquivo { get; set; }

    public DateTime? DataEnvio { get; set; }

    public int CandidatosId { get; set; }

    public int VagasId { get; set; }

    public virtual Candidato Candidatos { get; set; } = null!;

    public virtual Vaga Vagas { get; set; } = null!;
}
