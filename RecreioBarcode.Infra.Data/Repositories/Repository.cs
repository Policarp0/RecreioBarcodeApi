using Microsoft.EntityFrameworkCore;
using RecreioBarcode.Domain.Interfaces;
using RecreioBarcode.Infra.Data.Context;
using System.Linq.Expressions;

namespace RecreioBarcode.Infra.Data.Repositories;

public class Repository<T>(ApplicationContext context) : IRepository<T> where T : class
{
    protected readonly ApplicationContext _context = context;


    public async Task<T?> GetByIdAsync(int id)
    {
        return await _context.Set<T>().FindAsync(id);
    }
    public async Task<T?> GetWhereAsync(Expression<Func<T, bool>> predicate)
    {
        return await _context.Set<T>().FirstOrDefaultAsync(predicate);
    }
    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await _context.Set<T>().ToListAsync();
    }
    public async Task<IEnumerable<T>> GetAllWhereAsync(Expression<Func<T, bool>> predicate)
    {
        return await _context.Set<T>().Where(predicate).ToListAsync();
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
