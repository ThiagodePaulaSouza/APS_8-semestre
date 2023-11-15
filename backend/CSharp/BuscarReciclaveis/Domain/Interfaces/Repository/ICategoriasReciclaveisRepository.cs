using BuscarReciclaveis.Domain.Entidades;

namespace BuscarReciclaveis.Domain.Interfaces.Repository
{
    public interface ICategoriasReciclaveisRepository : IBaseRepository<CategoriasReciclaveis>
    {
        public Task<IList<CategoriasReciclaveis>> SelectAllAsync();
    }
}