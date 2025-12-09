namespace projetoJobs.Models
{
    public class Empresa
    {
        public int Id { get; set; }
        public string Nome { get; set; } = "";
        public string CNPJ { get; set; } = "";
        public string Email { get; set; } = "";
        public string Senha { get; set; } = "";

        public string? Telefone { get; set; }
        public string? Cidade { get; set; }
        public string? Estado { get; set; }
        public string? Descricao { get; set; }

        // Relação 1:N → Uma empresa tem várias vagas
        public List<Vaga>? Vagas { get; set; }
    }
}
