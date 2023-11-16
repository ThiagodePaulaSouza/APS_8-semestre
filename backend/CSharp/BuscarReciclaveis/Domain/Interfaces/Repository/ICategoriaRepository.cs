using BuscarReciclaveis.Domain.Entidades;

namespace BuscarReciclaveis.Domain.Interfaces.Repository
{
    public interface ICategoriaRepository : IBaseRepository<CategoriaReciclavel>
    {
        public Task<IList<CategoriaReciclavel>> SelectAllAsync();
        public Task<CategoriaReciclavel> SelectByIdAtivoAsync(int id);
        public Task<CategoriaReciclavel> SelectByCategoryIdAtivoAsync(int id);
    }
}