using Microsoft.EntityFrameworkCore;
using projetoJobs.Models;

namespace projetoJobs.Contexts
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Candidato> Candidatos { get; set; }
        public DbSet<Empresa> Empresas { get; set; }
        public DbSet<Vaga> Vagas { get; set; }
    }
}
