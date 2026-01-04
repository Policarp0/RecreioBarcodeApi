using Microsoft.EntityFrameworkCore;
using RecreioBarcode.Domain.Entities;
using RecreioBarcode.Domain.Interfaces;
using RecreioBarcode.Infra.Data.Context;

namespace RecreioBarcode.Infra.Data.Repositories
{
    public class InventoryItemOutRepository : IInventoryItemOutRepository
    {
        private readonly ApplicationContext _context;
        public InventoryItemOutRepository(ApplicationContext context) { _context = context; }

        public async Task<InventoryItemOut> CreateAsync(InventoryItemOut inventoryItemOut)
        {
            _context.InventoryItemsOut.Add(inventoryItemOut);
            await _context.SaveChangesAsync();
            return inventoryItemOut;
        }

        public async Task<InventoryItemOut> DeleteAsync(InventoryItemOut inventoryItemOut)
        {
            _context.InventoryItemsOut.Remove(inventoryItemOut);
            await _context.SaveChangesAsync();
            return inventoryItemOut;
        }

        public async Task<IEnumerable<InventoryItemOut>> GetAllByInventoryIdAsync(int inventoryId)
        {
            return await _context.InventoryItemsOut
                .Where(x => x.InventoryId == inventoryId)
                .ToListAsync();
        }

        public async Task<InventoryItemOut?> GetByIdAsync(int id)
        {
           return await _context.InventoryItemsOut.FindAsync(id);
        }

        public async Task<InventoryItemOut> UpdateAsync(InventoryItemOut inventoryItemOut)
        {
            _context.InventoryItemsOut.Update(inventoryItemOut);
            await _context.SaveChangesAsync();
            return inventoryItemOut;
        }
    }
}
