using RecreioBarcode.Application.DTOs;

namespace RecreioBarcode.Application.Interfaces
{
    public interface InventoryLineService : IService<InventoryLineDTO, int>
    {
        Task<IEnumerable<InventoryLineDTO>> GetAllByInventoryIdAsync(int inventoryId);
        Task<IEnumerable<InventoryLineDTO>> GetAllByInventoryLocationIdAsync(int inventoryLocationId);
        Task<IEnumerable<InventoryLineDTO>> GetAllByInventoryLocationRangeAsync(
            int inventoryId,
            char zonaInitial, char zonaFinal,
            int ruaInicial, int ruaFinal,
            int estanteInitial, int estanteFinal,
            char prateleiraInitial, char prateleiraFinal,
            int numeroInitial, int numeroFinal);
    }
}
