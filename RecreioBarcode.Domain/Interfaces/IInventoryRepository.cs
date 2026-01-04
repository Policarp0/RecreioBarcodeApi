using RecreioBarcode.Domain.Entities;

namespace RecreioBarcode.Domain.Interfaces
{
    public interface IInventoryRepository
    {
        Task<Inventory> GetByIdAsync(int id);
        Task<IEnumerable<Inventory>> GetAllActiveAsync();
        Task<IEnumerable<Inventory>> GetAllInactiveAsync();
        
        Task<Inventory> CreateAssync(Inventory inventory);
        Task<Inventory> UpdateAssync(Inventory inventory);
        Task<Inventory> DeleteAsync(int id);
    }
}
