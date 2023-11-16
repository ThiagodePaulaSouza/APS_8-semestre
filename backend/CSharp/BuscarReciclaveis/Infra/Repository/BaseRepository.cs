using BuscarReciclaveis.Domain.Enums;
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

        public virtual async Task AddAsync(T entity)
        {
            await this.DbSet.AddAsync(entity);
            _context.SaveChanges();
        }
        
        public virtual async Task AddManyAsync(IList<T> entity)
        {
            await this.DbSet.AddRangeAsync(entity);
            _context.SaveChanges();
        }

        public virtual void Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public virtual async Task Remove(int id)
        {
            this.DbSet.Remove(await SelectByIdAsync(id));
            _context.SaveChanges();
        }

        public virtual async Task<T> SelectByIdAsync(int id)
        {
            return await this.DbSet.FindAsync(id);
        }

        public virtual void SaveChanges()
        {
            _context.SaveChanges();
        }
        
    }
}