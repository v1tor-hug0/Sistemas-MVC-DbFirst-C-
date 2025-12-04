using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using SistemaAnimal.Models;

namespace SistemaAnimal.Data;

public partial class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TabelaAnimai> TabelaAnimais { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TabelaAnimai>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_TabelaFuncionario");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
