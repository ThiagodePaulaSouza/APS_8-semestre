using BuscarReciclaveis.Domain.Interfaces.Repository;

namespace BuscarReciclaveis.Domain.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IItemRepository IItemReciclavelRepository { get; }
        ICategoriaRepository ICategoriaReciclavel { get; }

        Task Commit();
    }
}
