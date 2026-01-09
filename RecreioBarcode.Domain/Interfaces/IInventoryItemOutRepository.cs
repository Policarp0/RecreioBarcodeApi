using RecreioBarcode.Domain.Entities;

namespace RecreioBarcode.Domain.Interfaces
{
    public interface IInventoryItemOutRepository : IRepository<InventoryItemOut>
    {
        Task<IEnumerable<InventoryItemOut>> GetAllByInventoryIdAsync(int inventoryId);
    }
}
