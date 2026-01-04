using RecreioBarcode.Domain.Entities;

namespace RecreioBarcode.Domain.Interfaces
{
    public interface IInventoryItemOutRepository
    {
        Task<InventoryItemOut?> GetByIdAsync(int id);
        Task<IEnumerable<InventoryItemOut>> GetAllByInventoryIdAsync(int inventoryId);

        Task<InventoryItemOut> CreateAsync(InventoryItemOut inventoryItemOut);
        Task<InventoryItemOut> UpdateAsync(InventoryItemOut inventoryItemOut);
        Task<InventoryItemOut> DeleteAsync(InventoryItemOut inventoryItemOut);
    }
}
