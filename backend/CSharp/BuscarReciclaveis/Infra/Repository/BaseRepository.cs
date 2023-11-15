using BuscarReciclaveis.Domain.Interfaces.Repository;
using BuscarReciclaveis.Infra.Database;
using Microsoft.EntityFrameworkCore;

namespace BuscarReciclaveis.Infra.Repository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected readonly AppDbContext _context;
        protected DbSet<T> DbSet;
        public BaseRepository(AppDbContext appDbContext)
        {
            _context = appDbContext;            
            this.DbSet = this._context.Set<T>();
        }

        public virtual void Add(T entity)
        {
            this.DbSet.Add(entity);
            _context.SaveChanges();
        }

        public virtual void Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public virtual void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}