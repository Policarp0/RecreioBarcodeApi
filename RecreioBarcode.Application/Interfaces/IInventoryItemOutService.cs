using RecreioBarcode.Application.DTOs;

namespace RecreioBarcode.Application.Interfaces
{
    public interface InventoryItemOutService : IService<InventoryItemOutDTO,int>
    {
        Task<IEnumerable<InventoryDTO>> GetAllByInventoryId(int inventoryId);
    }
}
