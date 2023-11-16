using BuscarReciclaveis.Domain.Entidades;
using Microsoft.EntityFrameworkCore;

namespace BuscarReciclaveis.Infra.Database
{
    public class AppDbContext : DbContext
    {
        public DbSet<ItemReciclavel> ItemReciclavel { get; set; }
        public DbSet<CategoriaReciclavel> CategoriaReciclavel { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    }
}