using RecreioBarcode.Domain.Entities;

namespace RecreioBarcode.Domain.Interfaces
{
    public interface IInvetoryLineRepository
    {
        Task<InventoryLine> GetByIdAsync(int id);
        Task<IEnumerable<InventoryLine>> GetAllByInventoryLocationIdAsync(int inventoryLocationId);
        Task<IEnumerable<InventoryLine>> GetAllByInventoryIdAsync(int inventoryId);
        Task<IEnumerable<InventoryLine>> GetAllByInventoryLocationRangeAsync(
            int inventoryId,
            char zonaInitial, char zonaFinal,
            int ruaInicial, int ruaFinal,
            int estanteInitial, int estanteFinal,
            char prateleiraInitial, char prateleiraFinal,
            int numeroInitial, int numeroFinal);

        Task<InventoryLine> CreateAsync(InventoryLine inventoryLine);
        Task<InventoryLine> Update(InventoryLine inventoryLine);
        Task<InventoryLine> Delete(int id);
    }
}
