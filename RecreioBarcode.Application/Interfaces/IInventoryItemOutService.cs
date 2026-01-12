using RecreioBarcode.Application.DTOs;

namespace RecreioBarcode.Application.Interfaces
{
    public interface IInventoryItemOutService
    {
        Task<IEnumerable<InventoryItemOutDTO>> GetAllByInventoryId(int inventoryId);
    }
}
