﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using projetoJobs.Models;
using Microsoft.AspNetCore.Mvc;

namespace projetoJobs.Contexts;

public partial class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Candidato> Candidatos { get; set; }

    public virtual DbSet<Curriculo> Curriculos { get; set; }

    public virtual DbSet<Empresa> Empresas { get; set; }

    public virtual DbSet<Vaga> Vagas { get; set; }

    // ✅ ACRESCENTADO
    public virtual DbSet<Candidatura> Candidaturas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ProjetoJobs;Integrated Security=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Candidato>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Candidat__3213E83FFBA023F9");

            entity.ToTable("Candidato");

            entity.HasIndex(e => e.Cpf, "UQ__Candidat__C1F897317D497801").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
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
            entity.Property(e => e.ResumoPerfil).IsUnicode(false);
            entity.Property(e => e.Senha)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.Telefone)
                .HasMaxLength(11)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Curriculo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Curricul__3213E83F115FFA98");

            entity.ToTable("Curriculo");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CaminhoArquivo)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("caminho_arquivo");
            entity.Property(e => e.CandidatosId).HasColumnName("Candidatos_id");
            entity.Property(e => e.DataEnvio)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("data_envio");
            entity.Property(e => e.NomeArquivo)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("nome_arquivo");
            entity.Property(e => e.VagasId).HasColumnName("Vagas_id");

            entity.HasOne(d => d.Candidato).WithMany(p => p.Curriculos)
                .HasForeignKey(d => d.CandidatosId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Curriculo__Candi__403A8C7D");

            entity.HasOne(d => d.Vaga).WithMany(p => p.Curriculos)
                .HasForeignKey(d => d.VagasId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Curriculo__Vagas__412EB0B6");
        });

        modelBuilder.Entity<Empresa>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Empresa__3213E83F2D1F8529");

            entity.ToTable("Empresa");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Cidade)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Cnpj)
                .HasMaxLength(14)
                .IsUnicode(false)
                .HasColumnName("CNPJ");
            entity.Property(e => e.Descricao).IsUnicode(false);
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
            entity.HasKey(e => e.Id).HasName("PK__Vaga__3213E83FB5EA088B");

            entity.ToTable("Vaga");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Cidade)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.DescricaoVaga).IsUnicode(false);
            entity.Property(e => e.EmpresasId).HasColumnName("Empresas_id");
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

            entity.HasOne(d => d.Empresas).WithMany(p => p.Vagas)
                .HasForeignKey(d => d.EmpresasId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Vaga__Empresas_i__3C69FB99");
        });

        // ----------------------------------------------------------
        // ✅ ENTIDADE CANDIDATURA — ADICIONADO SEM MEXER NO RESTANTE
        // ----------------------------------------------------------
        modelBuilder.Entity<Candidatura>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.ToTable("Candidatura");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DataCandidatura).HasColumnType("datetime");

            entity.HasOne(c => c.Candidato)
                .WithMany(c => c.Candidaturas)
                .HasForeignKey(c => c.CandidatoId)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(c => c.Vaga)
                .WithMany(v => v.Candidaturas)
                .HasForeignKey(c => c.VagaId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        OnModelCreatingPartial(modelBuilder);
        modelBuilder.Entity<Candidatura>(entity =>
{
    entity.HasKey(e => e.Id);

    entity.ToTable("Candidatura");

    entity.Property(e => e.Id).HasColumnName("id");
    entity.Property(e => e.DataCandidatura).HasColumnType("datetime");

    entity.HasOne(c => c.Candidato)
        .WithMany(c => c.Candidaturas)
        .HasForeignKey(c => c.CandidatoId)
        .OnDelete(DeleteBehavior.Cascade);

    entity.HasOne(c => c.Vaga)
        .WithMany(v => v.Candidaturas)
        .HasForeignKey(c => c.VagaId)
        .OnDelete(DeleteBehavior.Cascade);
});

    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    
    
}
