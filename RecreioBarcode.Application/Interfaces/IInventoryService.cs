using RecreioBarcode.Application.DTOs;

namespace RecreioBarcode.Application.Interfaces
{
    public interface IInventoryService : IService<InventoryDTO,int>
    {
        Task<IEnumerable<InventoryDTO>> GetAllActiveAsync();
        Task<IEnumerable<InventoryDTO>> GetAllInactiveAsync();
    }
}
