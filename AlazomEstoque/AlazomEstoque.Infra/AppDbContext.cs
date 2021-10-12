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

        protected override void OnConfiguring(DbContextOptionsBuilder options)
         => options.UseSqlite(@"Data Source=C:\dados\Alazomdb.db");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EstoqueVagas>()
                .HasData(
                    new EstoqueVagas() { Id = 1, QtdAtual = 0, UltimaData = DateTime.Now }
                ) ;
        }
    }
}
