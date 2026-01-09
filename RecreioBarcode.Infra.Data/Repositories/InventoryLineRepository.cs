using Microsoft.EntityFrameworkCore;
using RecreioBarcode.Domain.Entities;
using RecreioBarcode.Domain.Interfaces;
using RecreioBarcode.Infra.Data.Context;

namespace RecreioBarcode.Infra.Data.Repositories
{
    public class InventoryLineRepository : Repository<InventoryLine>, IInventoryLineRepository
    {
        public InventoryLineRepository(ApplicationContext context) : base(context) { }

        public async Task<IEnumerable<InventoryLine>> GetAllByInventoryIdAsync(int inventoryId)
        {
            return await _context.InventoryLines
                .Include(l => l.InventoryLocation)
                .Where(l => l.InventoryLocation.InventoryId == inventoryId)
                .ToListAsync();
        }

        public async Task<IEnumerable<InventoryLine>> GetAllByInventoryLocationIdAsync(int inventoryLocationId)
        {
            return await _context.InventoryLines
                .Where(l => l.InventoryLocationId == inventoryLocationId)
                .ToListAsync();
        }

        public async Task<IEnumerable<InventoryLine>> GetAllByInventoryLocationRangeAsync(
            int inventoryId,
            char zonaInitial, char zonaFinal, 
            int ruaInicial, int ruaFinal, 
            int estanteInitial, int estanteFinal, 
            char prateleiraInitial, char prateleiraFinal, 
            int numeroInitial, int numeroFinal)
        {
            return await _context.InventoryLines
                .Include(l => l.InventoryLocation)
                    .ThenInclude(il => il.Location)
                .Where(l =>
                    l.InventoryLocation.InventoryId == inventoryId &&

                    l.InventoryLocation.Location.Zona >= zonaInitial &&
                    l.InventoryLocation.Location.Zona <= zonaFinal &&

                    l.InventoryLocation.Location.Rua >= ruaInicial &&
                    l.InventoryLocation.Location.Rua <= ruaFinal &&

                    l.InventoryLocation.Location.Estante >= estanteInitial &&
                    l.InventoryLocation.Location.Estante <= estanteFinal &&

                    l.InventoryLocation.Location.Prateleira >= prateleiraInitial &&
                    l.InventoryLocation.Location.Prateleira <= prateleiraFinal &&

                    l.InventoryLocation.Location.Numero >= numeroInitial &&
                    l.InventoryLocation.Location.Numero <= numeroFinal
        )
        .ToListAsync();
        }
    }
}
