using BuscarReciclaveis.Domain.Entidades;

namespace BuscarReciclaveis.Domain.Interfaces.Repository
{
    public interface IItemsReciclaveisRepository : IBaseRepository<ItemsReciclaveis>
    {
        public Task<IList<ItemsReciclaveis>> SelectAllAsync();
    }
}