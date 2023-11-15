using BuscarReciclaveis.Domain.Entidades;
using BuscarReciclaveis.Domain.Enums;
using BuscarReciclaveis.Domain.Interfaces.Repository;
using BuscarReciclaveis.Infra.Database;
using Microsoft.EntityFrameworkCore;

namespace BuscarReciclaveis.Infra.Repository
{
    public class ItemsReciclaveisRepository : BaseRepository<ItemsReciclaveis>, IItemsReciclaveisRepository
    {
        public ItemsReciclaveisRepository(AppDbContext appDbContext) : base(appDbContext){ }

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
        public async Task<IList<ItemsReciclaveis>> SelectAllAsync()
        {
            var query = await _context.Set<ItemsReciclaveis>()
                .Where(x => x.Status == Status.Ativo)
                .ToListAsync();

            return query;
        }
    }
}