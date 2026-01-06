using RecreioBarcode.Domain.Entities;

namespace RecreioBarcode.Domain.Interfaces
{
    public interface IInventoryRepository
    {
        Task<Inventory?> GetByIdAsync(int id);
        Task<IEnumerable<Inventory>> GetAllActiveAsync();
        Task<IEnumerable<Inventory>> GetAllInactiveAsync();
        
        Task<Inventory> CreateAsync(Inventory inventory);
        Task<Inventory> UpdateAsync(Inventory inventory);
        Task<Inventory> DeleteAsync(Inventory inventory);
    }
}
