namespace BuscarReciclaveis.Domain.Interfaces.Repository
{
    public interface IBaseRepository<T>
    {
        Task AddAsync(T entity);
        Task AddManyAsync(IList<T> entity);
        void Update(T entity);
        Task Remove(int id);
        Task<T> SelectByIdAsync(int id);
        void SaveChanges();
    }
}