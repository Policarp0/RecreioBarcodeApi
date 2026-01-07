namespace RecreioBarcode.Application.Interfaces
{
    public interface IService<TEntity, TKey> where TEntity : class
    {
        Task<TEntity> GetByIdAsync(TKey id);
        Task CreateAsync(TEntity dto);
        Task UpdateAsync(TEntity dto);
        Task DeleteAsync(TKey id);

    }
}
