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
    }

}