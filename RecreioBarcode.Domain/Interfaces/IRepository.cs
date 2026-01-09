using System.Linq.Expressions;

namespace RecreioBarcode.Domain.Interfaces
{
    public interface IRepository<T>
    {
        Task<T?> Get(Expression<Func<T,bool>> predicate);
        Task<IEnumerable<T>> GetAll();
        T Create(T entity);
        T Update(T entity);
        T Delete(T entity);
    }
}
