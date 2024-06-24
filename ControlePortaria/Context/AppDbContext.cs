using ControlePortaria.Models;
using Microsoft.EntityFrameworkCore;


namespace ControlePortaria.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Pessoa> Pessoas { get; set; }
        public DbSet<Carro> Carros { get; set; }

        public DbSet<Portaria> Portarias { get; set; }


    }
}
