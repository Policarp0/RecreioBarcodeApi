using RecreioBarcode.Application.DTOs;

namespace RecreioBarcode.Application.Interfaces
{
    public interface IInventoryItemOutService : IService<InventoryItemOutDTO,int>
    {
        Task<IEnumerable<InventoryItemOutDTO>> GetAllByInventoryId(int inventoryId);
    }
}
