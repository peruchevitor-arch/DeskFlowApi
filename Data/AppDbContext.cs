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
    public DbSet<Chamado> Chamados {get; set;}


    protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Chamado>(entity =>
            {
                entity.HasKey(x => x.Id);

                entity.Property(x => x.Titulo)
                    .HasColumnName("Titulo");

                entity.Property(x => x.Descricao)
                    .HasColumnName("Descricao");
            });
        }

    }
}