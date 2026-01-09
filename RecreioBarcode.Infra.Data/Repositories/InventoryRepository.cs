using Microsoft.EntityFrameworkCore;
using RecreioBarcode.Domain.Entities;
using RecreioBarcode.Domain.Interfaces;
using RecreioBarcode.Infra.Data.Context;

namespace RecreioBarcode.Infra.Data.Repositories
{
    public class InventoryRepository : Repository<Inventory>, IInventoryRepository
    {
        public InventoryRepository(ApplicationContext context) : base(context) {}

        public async Task<IEnumerable<Inventory>> GetAllActiveAsync()
        {
            return await _context.Inventories.Where(x => x.IsActive == true).ToListAsync();
        }
        public async Task<IEnumerable<Inventory>> GetAllInactiveAsync()
        {
            return await _context.Inventories.Where(x => x.IsActive == false).ToListAsync();
        }
    }
}
