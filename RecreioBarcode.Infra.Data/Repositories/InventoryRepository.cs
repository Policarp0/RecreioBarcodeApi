using Microsoft.EntityFrameworkCore;
using RecreioBarcode.Domain.Entities;
using RecreioBarcode.Infra.Data.Context;

namespace RecreioBarcode.Infra.Data.Repositories
{
    public class InventoryRepository
    {
        private readonly ApplicationContext _context;

        public InventoryRepository(ApplicationContext context)
        {
            _context = context;
        }
        public async Task<Inventory> CreateInventoryAsync(Inventory inventory)
        {
            _context.Add(inventory);
            await _context.SaveChangesAsync();
            return inventory;
        }
    }
}
