using Microsoft.EntityFrameworkCore;
using RecreioBarcode.Domain.Entities;
using RecreioBarcode.Domain.Interfaces;
using RecreioBarcode.Infra.Data.Context;

namespace RecreioBarcode.Infra.Data.Repositories
{
    public class InventoryLineRepository : IInventoryLineRepository
    {
        private readonly ApplicationContext _context;
        public InventoryLineRepository(ApplicationContext context) { _context = context; }

        public async Task<InventoryLine> CreateAsync(InventoryLine inventoryLine)
        {
            _context.InventoryLines.Add(inventoryLine);
            await _context.SaveChangesAsync();
            return inventoryLine;
        }

        public async Task<InventoryLine> DeleteAsync(InventoryLine inventoryLine)
        {
            _context.InventoryLines.Remove(inventoryLine);
            await _context.SaveChangesAsync();
            return inventoryLine;
        }

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

        public async Task<InventoryLine?> GetByIdAsync(int id)
        {
            return await _context.InventoryLines.FindAsync(id);
        }

        public async Task<InventoryLine> UpdateAsync(InventoryLine inventoryLine)
        {
            _context.InventoryLines.Update(inventoryLine);
            await _context.SaveChangesAsync();
            return inventoryLine;
        }
    }
}
