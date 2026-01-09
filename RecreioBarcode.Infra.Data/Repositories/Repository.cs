using Microsoft.EntityFrameworkCore;
using RecreioBarcode.Domain.Interfaces;
using RecreioBarcode.Infra.Data.Context;
using System.Linq.Expressions;

namespace RecreioBarcode.Infra.Data.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly ApplicationContext _context;

        public Repository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<T?> Get(Expression<Func<T, bool>> predicate)
        {
            return await _context.Set<T>().FirstOrDefaultAsync(predicate);
        }
        public async Task<IEnumerable<T>> GetAll()
        {
            return await _context.Set<T>().ToArrayAsync();
        }
        public T Create(T entity)
        {
            _context.Set<T>().AddAsync(entity);
            return entity;

        }
        public T Update(T entity)
        {
            _context.Set<T>().Update(entity);
            return entity;

        }
        public T Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
            return entity;

        }
    }
}
