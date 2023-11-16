using BuscarReciclaveis.Domain.Entidades;
using BuscarReciclaveis.Domain.Enums;
using BuscarReciclaveis.Domain.Interfaces.Repository;
using BuscarReciclaveis.Infra.Database;
using Microsoft.EntityFrameworkCore;

namespace BuscarReciclaveis.Infra.Repository
{
    public class CategoriaRepository : BaseRepository<CategoriaReciclavel>, ICategoriaRepository
    {
        public CategoriaRepository(AppDbContext appDbContext) : base(appDbContext){ }

        public void Delete(int Id)
        {
            var caregoria = DbSet.First(x => x.Id == Id);

            if (caregoria.Status != (int)Status.Excluido)
            {
                caregoria.Status = (int)Status.Excluido;
                _context.Update(caregoria);
                SaveChanges();
            }
        }

        public async Task<IList<CategoriaReciclavel>> SelectAllAsync()
        {
            var query = await _context.Set<CategoriaReciclavel>()
                .Where(x => x.Status == Status.Ativo)
                .ToListAsync();

            return query;
        }

        public async Task<CategoriaReciclavel> SelectByIdAtivoAsync(int id)
        {
            var query = await _context.Set<CategoriaReciclavel>()
                .SingleOrDefaultAsync(x => x.Id == id && x.Status == Status.Ativo);

            return query;
        }

        public async Task<CategoriaReciclavel> SelectByCategoryIdAtivoAsync(int categoryId)
        {
            var query = await _context.Set<CategoriaReciclavel>()
                .SingleOrDefaultAsync(x => x.IdCategoria == categoryId && x.Status == Status.Ativo);

            return query;
        }
    }
}