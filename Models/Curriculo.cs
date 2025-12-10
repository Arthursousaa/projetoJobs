using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace projetoJobs.Models
{
    public class Curriculo
    {
        public int Id { get; set; }

        // Se os nomes da sua tabela são diferentes, ajuste com [Column("nome_arquivo")]
        public string? NomeArquivo { get; set; }
        public string? CaminhoArquivo { get; set; }
        public DateTime DataEnvio { get; set; }

        // FK — nomes sugeridos. Se a coluna no banco for Vagas_id use [Column("Vagas_id")]
        [Column("Candidatos_id")]
        public int CandidatosId { get; set; }

        [Column("Vagas_id")]
        public int VagasId { get; set; }

        // Propriedades de navegação
        public Candidato? Candidato { get; set; }
        public Vaga? Vaga { get; set; }
    }
}
