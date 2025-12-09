namespace projetoJobs.Models
{
    public class Vaga
    {
        public int Id { get; set; }
        public string NomeVaga { get; set; } = "";
        public string? Cidade { get; set; }
        public string? Estado { get; set; }
        public TimeSpan HoraInicio { get; set; }
        public TimeSpan HoraFim { get; set; }
        public decimal Salario { get; set; }
        public string? TipoContrato { get; set; }
        public string? NivelExperiencia { get; set; }
        public string? DescricaoVaga { get; set; }

        // FK
        public int Empresas_Id { get; set; }

        // Navegação (nome correto!)
        public Empresa? Empresa { get; set; }

        public List<Curriculo>? Curriculos { get; set; }
    }
}
