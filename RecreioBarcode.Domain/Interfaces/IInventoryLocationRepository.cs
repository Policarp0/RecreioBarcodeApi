using RecreioBarcode.Domain.Entities;

namespace RecreioBarcode.Domain.Interfaces
{
    public interface IInventoryLocationRepository
    {
        Task<InventoryLocation> GetByInventoryIdAsync(int id);
        Task<IEnumerable<InventoryLocation>> GetAllByZona(int inventoryId, char zona);
        Task<IEnumerable<InventoryLocation>> GetAllByRua(int inventoryId, char rua);
        Task<IEnumerable<InventoryLocation>> GetAllByEstante(int inventoryId, char estante);
        Task<IEnumerable<InventoryLocation>> GetAllByPrateleira(int inventoryId, char prateleira);
        Task<IEnumerable<InventoryLocation>> GetAllByNumero(int inventoryId, char numero);

        Task<InventoryLocation> CreateAsync(InventoryLocation inventoryLocation);
        Task<InventoryLocation> Update(InventoryLocation inventoryLocation);
        Task<InventoryLocation> Delete(int id);
    }
}
