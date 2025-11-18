using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using projetoJobs.Models;

namespace projetoJobs.Contexts;

public partial class JobsContext : DbContext
{
    public JobsContext()
    {
    }

    public JobsContext(DbContextOptions<JobsContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Candidato> Candidatos { get; set; }

    public virtual DbSet<Empresa> Empresas { get; set; }

    public virtual DbSet<Vaga> Vagas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Jobs;Integrated Security=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Candidato>(entity =>
        {
            entity.HasKey(e => e.IdCandidato).HasName("PK__Candidat__25E28FCEDFFF5E5D");

            entity.HasIndex(e => e.Cpf, "UQ__Candidat__C1F897310354E3CE").IsUnique();

            entity.Property(e => e.IdCandidato).HasColumnName("id_Candidato");
            entity.Property(e => e.Cidade)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Cpf)
                .HasMaxLength(11)
                .IsUnicode(false)
                .HasColumnName("CPF");
            entity.Property(e => e.Email)
                .HasMaxLength(70)
                .IsUnicode(false);
            entity.Property(e => e.Estado)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Nome)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.ResumoPerfil).HasColumnType("text");
            entity.Property(e => e.Senha)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.Telefone)
                .HasMaxLength(11)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Empresa>(entity =>
        {
            entity.HasKey(e => e.IdEmpresa).HasName("PK__Empresa__DE87A153A5BDFE0C");

            entity.ToTable("Empresa");

            entity.Property(e => e.IdEmpresa).HasColumnName("id_Empresa");
            entity.Property(e => e.Cidade)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Cnpj)
                .HasMaxLength(14)
                .IsUnicode(false)
                .HasColumnName("CNPJ");
            entity.Property(e => e.Descricao).HasColumnType("text");
            entity.Property(e => e.Email)
                .HasMaxLength(70)
                .IsUnicode(false);
            entity.Property(e => e.Estado)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Nome)
                .HasMaxLength(120)
                .IsUnicode(false);
            entity.Property(e => e.Senha)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.Telefone)
                .HasMaxLength(11)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Vaga>(entity =>
        {
            entity.HasKey(e => e.IdVaga).HasName("PK__Vaga__B251BD5BB5AB343E");

            entity.ToTable("Vaga");

            entity.Property(e => e.IdVaga).HasColumnName("id_Vaga");
            entity.Property(e => e.Cidade)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.DescricaoVaga).HasColumnType("text");
            entity.Property(e => e.EmpresaId).HasColumnName("Empresa_id");
            entity.Property(e => e.Estado)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.NivelExperiencia)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.NomeVaga)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Salario).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.TipoContrato)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Empresa).WithMany(p => p.Vagas)
                .HasForeignKey(d => d.EmpresaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Vaga__Empresa_id__4BAC3F29");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
