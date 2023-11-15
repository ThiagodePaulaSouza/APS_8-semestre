namespace BuscarReciclaveis.Domain.Interfaces.Repository
{
    public interface IBaseRepository<T>
    {
        void Add(T entity);
        void Update(T entity);
        void SaveChanges();
    }
}