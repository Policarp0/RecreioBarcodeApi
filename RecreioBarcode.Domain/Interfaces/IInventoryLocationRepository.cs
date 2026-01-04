using RecreioBarcode.Domain.Entities;

namespace RecreioBarcode.Domain.Interfaces
{
    public interface IInventoryLocationRepository
    {
        Task<InventoryLocation?> GetByInventoryIdAsync(int id);
        Task<IEnumerable<InventoryLocation>> GetAllByZonaAsync(int inventoryId, char zona);
        Task<IEnumerable<InventoryLocation>> GetAllByRuaAsync(int inventoryId, char rua);
        Task<IEnumerable<InventoryLocation>> GetAllByEstanteAsync(int inventoryId, char estante);
        Task<IEnumerable<InventoryLocation>> GetAllByPrateleiraAsync(int inventoryId, char prateleira);
        Task<IEnumerable<InventoryLocation>> GetAllByNumeroAsync(int inventoryId, char numero);

        Task<InventoryLocation> CreateAsync(InventoryLocation inventoryLocation);
        Task<InventoryLocation> UpdateAsync(InventoryLocation inventoryLocation);
        Task<InventoryLocation> DeleteAsync(InventoryLocation inventoryLocation);
    }
}
