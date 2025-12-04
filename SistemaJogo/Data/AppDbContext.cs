using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using SistemaJogo.Models;

namespace SistemaJogo.Data;

public partial class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TabelaJogo> TabelaJogos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TabelaJogo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_TabelaFuncionario");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
