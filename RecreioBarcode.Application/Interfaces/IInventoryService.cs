using RecreioBarcode.Application.DTOs;

namespace RecreioBarcode.Application.Interfaces
{
    public interface IInventoryService
    {
        Task<InventoryDTO> GetById(int id);
        Task<IEnumerable<InventoryDTO>> GetAllActiveAsync();
        Task<IEnumerable<InventoryDTO>> GetAllInactiveAsync();
        Task<InventoryDTO> CreateFromCsv(InventoryDTO dto);
        Task<bool> UpdateAsync(InventoryDTO dto);
        Task<bool> DeleteAsync(int id);
    }
}
