using AlazomEstoque.Core.Domain.Model;
using Microsoft.EntityFrameworkCore;
using System;

namespace AlazomEstoque.Infra
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<EstoqueAbertura> EstoqueAbertura { get; set; }
        public DbSet<EstoqueVagas> EstoqueVaga { get; set; }
        public DbSet<CadastroFornecedor> CadFornecedor { get; set; }
    
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EstoqueAbertura>()
                .HasData(
                    new EstoqueAbertura() { IdAbertura = 1, QtdDia = 12, HorarioAbertura = DateTime.Now }
                ); ;
        }
    }
}
