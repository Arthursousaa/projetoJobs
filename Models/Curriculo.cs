namespace projetoJobs.Models
{
    public class Curriculo
    {
        public int Id { get; set; }
        public string? Nome_Arquivo { get; set; }
        public string? Caminho_Arquivo { get; set; }
        public DateTime Data_Envio { get; set; } = DateTime.Now;

        // FK
        public int Candidatos_Id { get; set; }
        public Candidato? Candidato { get; set; }

        public int Vagas_Id { get; set; }
        public Vaga? Vaga { get; set; }
    }
}
