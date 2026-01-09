using RecreioBarcode.Domain.Entities;

namespace RecreioBarcode.Domain.Interfaces
{
    public interface IInventoryLocationRepository : IRepository<InventoryLocation>
    {
        Task<IEnumerable<InventoryLocation>> GetAllByInventoryIdAsync(int inventoryId);
        Task<IEnumerable<InventoryLocation>> GetAllByZonaAsync(int inventoryId, char zona);
        Task<IEnumerable<InventoryLocation>> GetAllByRuaAsync(int inventoryId, char rua);
        Task<IEnumerable<InventoryLocation>> GetAllByEstanteAsync(int inventoryId, char estante);
        Task<IEnumerable<InventoryLocation>> GetAllByPrateleiraAsync(int inventoryId, char prateleira);
        Task<IEnumerable<InventoryLocation>> GetAllByNumeroAsync(int inventoryId, char numero);
    }
}
