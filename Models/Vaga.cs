using System;
using System.Collections.Generic;

namespace projetoJobs.Models;

public partial class Vaga
{
    public int IdVaga { get; set; }

    public string NomeVaga { get; set; } = null!;

    public string? Cidade { get; set; }

    public string? Estado { get; set; }

    public TimeOnly HoraInicio { get; set; }

    public TimeOnly HoraFim { get; set; }

    public decimal Salario { get; set; }

    public string? TipoContrato { get; set; }

    public string? NivelExperiencia { get; set; }

    public string? DescricaoVaga { get; set; }

    public int EmpresaId { get; set; }

    public virtual Empresa Empresa { get; set; } = null!;
}
