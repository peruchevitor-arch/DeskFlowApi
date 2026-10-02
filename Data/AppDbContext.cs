using DeskFlowApi.Models;
using Microsoft.EntityFrameworkCore;


namespace DeskFlowApi.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }
        public DbSet<Chamado> Chamados { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Interacao> Interacoes { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           modelBuilder.Entity<Chamado>()
                .HasOne(c => c.Categoria)
                .WithMany()
                .HasForeignKey(c => c.CategoriaId);
           modelBuilder.Entity<Interacao>()
                .HasOne(i => i.Chamado)
                .WithMany(c => c.Interacoes)
                .HasForeignKey(i => i.ChamadoId);

            
        }
    }
}