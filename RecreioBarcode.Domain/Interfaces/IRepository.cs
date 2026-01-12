using System.Linq.Expressions;

namespace RecreioBarcode.Domain.Interfaces
{
    public interface IRepository<T>
    {
        Task <IEnumerable<T>> GetAll(Expression<Func<T, bool>> predicate);
        Task<T?> Get(Expression<Func<T,bool>> predicate);
        T Create(T entity);
        T Update(T entity);
        T Delete(T entity);
    }
}
