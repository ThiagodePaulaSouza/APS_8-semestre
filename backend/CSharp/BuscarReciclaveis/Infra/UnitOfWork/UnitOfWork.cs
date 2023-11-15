using BuscarReciclaveis.Domain.Interfaces.Repository;
using BuscarReciclaveis.Domain.UnitOfWork;
using BuscarReciclaveis.Infra.Database;
using BuscarReciclaveis.Infra.Repository;

namespace BuscarReciclaveis.Infra.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _dbContext;
        public UnitOfWork(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public ICategoriasReciclaveisRepository _categoriasRepository { get; set; }
        public ICategoriasReciclaveisRepository ICategoriasReciclaveis => _categoriasRepository ??= new CategoriasReciclaveisRepository(_dbContext);

        public IItemsReciclaveisRepository _itemsRepository { get; set; }
        public IItemsReciclaveisRepository IItemsReciclaveisRepository => _itemsRepository ??= new ItemsReciclaveisRepository(_dbContext);


        public async Task Commit()
        {
            await _dbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
        }
    }
}
