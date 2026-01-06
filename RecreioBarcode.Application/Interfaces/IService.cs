namespace RecreioBarcode.Application.Interfaces
{
    public interface IService<TEntity, TKey> where TEntity : class
    {
        Task<TEntity?> GetByIdAsync(TKey id);
        Task<TEntity> CreateAsync(TEntity dto);
        Task<TEntity> UpdateAsync(TEntity dto);
        Task<TEntity> DeleteAsync(TEntity dto);

    }
}
