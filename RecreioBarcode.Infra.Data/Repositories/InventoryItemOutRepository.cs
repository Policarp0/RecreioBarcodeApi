using Microsoft.EntityFrameworkCore;
using RecreioBarcode.Domain.Entities;
using RecreioBarcode.Domain.Interfaces;
using RecreioBarcode.Infra.Data.Context;

namespace RecreioBarcode.Infra.Data.Repositories
{
    public class InventoryItemOutRepository : Repository<InventoryItemOut>, IInventoryItemOutRepository
    {
        public InventoryItemOutRepository(ApplicationContext context) : base(context) { }

        public async Task<IEnumerable<InventoryItemOut>> GetAllByInventoryIdAsync(int inventoryId)
        {
            return await _context.InventoryItemsOut
                .Where(x => x.InventoryId == inventoryId)
                .ToListAsync();
        }
    }
}
