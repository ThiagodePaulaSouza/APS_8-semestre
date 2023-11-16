using BuscarReciclaveis.Domain.Entidades;

namespace BuscarReciclaveis.Domain.Interfaces.Repository
{
    public interface IItemRepository : IBaseRepository<ItemReciclavel>
    {
        public Task<IList<ItemReciclavel>> SelectAllAsync();
        public Task<ItemReciclavel> SelectByIdAtivoAsync(int id);
    }
}