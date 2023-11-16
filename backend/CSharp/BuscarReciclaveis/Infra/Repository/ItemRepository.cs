using BuscarReciclaveis.Domain.Entidades;
using BuscarReciclaveis.Domain.Enums;
using BuscarReciclaveis.Domain.Interfaces.Repository;
using BuscarReciclaveis.Infra.Database;
using Microsoft.EntityFrameworkCore;

namespace BuscarReciclaveis.Infra.Repository
{
    public class ItemRepository : BaseRepository<ItemReciclavel>, IItemRepository
    {
        public ItemRepository(AppDbContext appDbContext) : base(appDbContext){ }

        public void Delete(int Id)
        {
            var item = DbSet.First(x => x.Id == Id);

            if (item.Status != Status.Excluido)
            {
                item.Status = Status.Excluido;
                _context.Update(item);
                SaveChanges();
            }
        }
        public async Task<IList<ItemReciclavel>> SelectAllAsync()
        {
            var query = await _context.Set<ItemReciclavel>()
                .Where(x => x.Status == Status.Ativo)
                .Include(x => x.CategoriaReciclavel)
                .ToListAsync();

            return query;
        }

        public async Task<ItemReciclavel> SelectByIdAtivoAsync(int id)
        {
            var query = await _context.Set<ItemReciclavel>()
                .SingleOrDefaultAsync(x => x.Id == id && x.Status == Status.Ativo);

            return query;
        }

    }
}