using Microsoft.EntityFrameworkCore;
using projetoJobs.Models;

namespace projetoJobs.Contexts
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Empresa> Empresas { get; set; } = null!;
        public DbSet<Candidato> Candidatos { get; set; } = null!;
        public DbSet<Vaga> Vagas { get; set; } = null!;
        public DbSet<Curriculo> Curriculos { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Curriculo>()
                .HasOne(c => c.Vaga)
                .WithMany(v => v.Curriculos)
                .HasForeignKey(c => c.VagasId)
                .OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(modelBuilder);
        }
    }
}
