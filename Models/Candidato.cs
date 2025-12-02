using System;
using System.Collections.Generic;

namespace projetoJobs.Models;

public partial class Candidato
{
    public int Id { get; set; }

    public string Nome { get; set; } = null!;

    public string Cpf { get; set; } = null!;

    public DateOnly? DataNascimento { get; set; }

    public string? Email { get; set; }

    public string? Senha { get; set; }

    public string? Telefone { get; set; }

    public string? Cidade { get; set; }

    public string? Estado { get; set; }

    public string? ResumoPerfil { get; set; }

    public virtual ICollection<Curriculo> Curriculos { get; set; } = new List<Curriculo>();
}
