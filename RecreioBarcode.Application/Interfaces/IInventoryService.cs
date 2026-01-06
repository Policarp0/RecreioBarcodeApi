using RecreioBarcode.Application.DTOs;

namespace RecreioBarcode.Application.Interfaces
{
    public interface InventoryService : IService<InventoryDTO,int>
    {
        Task<IEnumerable<InventoryDTO>> GetAllActiveAsync();
        Task<IEnumerable<InventoryDTO>> GetAllInactiveAsync();
    }
}
