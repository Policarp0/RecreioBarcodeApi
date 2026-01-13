using System.Linq.Expressions;

namespace RecreioBarcode.Domain.Interfaces
{
    public interface IRepository<T>
    {
        Task<T?> GetByIdAsync(int id);
        Task<T?> GetWhereAsync(Expression<Func<T, bool>> predicate);
        Task <IEnumerable<T>> GetAllAsync();
        Task <IEnumerable<T>> GetAllWhereAsync(Expression<Func<T, bool>> predicate);
        
        T Create(T entity);
        T Update(T entity);
        T Delete(T entity);
    }
}
