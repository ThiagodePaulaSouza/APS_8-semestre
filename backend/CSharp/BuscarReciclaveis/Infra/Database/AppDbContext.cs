using BuscarReciclaveis.Domain.Entidades;
using Microsoft.EntityFrameworkCore;

namespace BuscarReciclaveis.Infra.Database
{
    public class AppDbContext : DbContext
    {
        public DbSet<ItemsReciclaveis> ItemsReciclaveis { get; set; }
        public DbSet<CategoriasReciclaveis> CategoriasReciclaveis { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    }
}