using Microsoft.EntityFrameworkCore;
using RecreioBarcode.Domain.Entities;
using RecreioBarcode.Domain.Interfaces;
using RecreioBarcode.Infra.Data.Context;

namespace RecreioBarcode.Infra.Data.Repositories
{
    public class InventoryRepository : IInventoryRepository
    {
        private readonly ApplicationContext _context;

        public InventoryRepository(ApplicationContext context) { _context = context; }

        public async Task<Inventory> CreateAsync(Inventory inventory)
        {
            _context.Inventories.Add(inventory);
            await _context.SaveChangesAsync();
            return inventory;
        }

        public async Task<Inventory> DeleteAsync(Inventory inventory)
        {
            _context.Inventories.Remove(inventory);
            await _context.SaveChangesAsync();
            return inventory;
        }

        public async Task<IEnumerable<Inventory>> GetAllActiveAsync()
        {
            return await _context.Inventories.Where(x => x.IsActive == true).ToListAsync();
        }

        public async Task<IEnumerable<Inventory>> GetAllInactiveAsync()
        {
            return await _context.Inventories.Where(x => x.IsActive == false).ToListAsync();
        }

        public async Task<Inventory?> GetByIdAsync(int id)
        {
            return await _context.Inventories.FindAsync(id);
        }

        public async Task<Inventory> UpdateAsync(Inventory inventory)
        {
            _context.Inventories.Update(inventory);
            await _context.SaveChangesAsync();
            return inventory;
        }
    }
}
