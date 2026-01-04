using RecreioBarcode.Domain.Entities;

namespace RecreioBarcode.Domain.Interfaces
{
    public interface IInventoryItemOutRepository
    {
        Task<InventoryItemOut> GetByIdAsync(int id);
        Task<InventoryItemOut> GetAllByInventoryId(int inventoryId);

        Task<InventoryItemOut> Create(InventoryItemOut inventoryItemOut);
        Task<InventoryItemOut> Update(InventoryItemOut inventoryItemOut);
        Task<InventoryItemOut> Delete(int id);
    }
}
