using System;
using System.Collections.Generic;

namespace projetoJobs.Models;

public partial class Empresa
{
    public int Id { get; set; }

    public string Nome { get; set; } = null!;

    public string Cnpj { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Senha { get; set; } = null!;

    public string? Telefone { get; set; }

    public string? Cidade { get; set; }

    public string? Estado { get; set; }

    public string? Descricao { get; set; }

    public virtual ICollection<Vaga> Vagas { get; set; } = new List<Vaga>();
}
