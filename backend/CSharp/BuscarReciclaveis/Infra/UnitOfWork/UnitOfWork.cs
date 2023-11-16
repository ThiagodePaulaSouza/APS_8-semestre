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

        public ICategoriaRepository _categoriaRepository { get; set; }
        public ICategoriaRepository ICategoriaReciclavel => _categoriaRepository ??= new CategoriaRepository(_dbContext);

        public IItemRepository _itemRepository { get; set; }
        public IItemRepository IItemReciclavelRepository => _itemRepository ??= new ItemRepository(_dbContext);


        public async Task Commit()
        {
            await _dbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
        }
    }
}
