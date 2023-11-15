using BuscarReciclaveis.Domain.Interfaces.Repository;

namespace BuscarReciclaveis.Domain.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IItemsReciclaveisRepository IItemsReciclaveisRepository { get; }
        ICategoriasReciclaveisRepository ICategoriasReciclaveis { get; }

        Task Commit();
    }
}
