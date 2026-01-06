using RecreioBarcode.Application.DTOs;

namespace RecreioBarcode.Application.Interfaces
{
    public interface InventoryLocationService : IService<InventoryLocationDTO,int>
    {
        Task<IEnumerable<InventoryLocationDTO>> GetByAllByInventoryIdAsync(int inventoryId);
        Task<IEnumerable<InventoryLocationDTO>> GetAllByZonaAsync(int inventoryId, char zona);
        Task<IEnumerable<InventoryLocationDTO>> GetAllByRuaAsync(int inventoryId, char rua);
        Task<IEnumerable<InventoryLocationDTO>> GetAllByEstanteAsync(int inventoryId, char estante);
        Task<IEnumerable<InventoryLocationDTO>> GetAllByPrateleiraAsync(int inventoryId, char prateleira);
        Task<IEnumerable<InventoryLocationDTO>> GetAllByNumeroAsync(int inventoryId, char numero);
    }
}
