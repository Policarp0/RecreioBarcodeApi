using Microsoft.EntityFrameworkCore;
using RecreioBarcode.Domain.Entities;
using RecreioBarcode.Domain.Interfaces;
using RecreioBarcode.Infra.Data.Context;

namespace RecreioBarcode.Infra.Data.Repositories;

public class InventoryRepository(ApplicationContext context) : IInventoryRepository
{
    private readonly ApplicationContext _context = context;
    
    public async Task<Inventory?> GetByIdAsync(int id, CancellationToken ct = default)
    {
        return await _context.Inventories
            .Include(i => i.InventoryLocations.Where()
                .ThenInclude(i => i.InventoryLines)
            .Include(i => i.InventoryItemsOut)
            .FirstOrDefaultAsync(i => i.Id == id, ct);
    }
    public async Task<Inventory?> GetSummaryByIdAsync(int id, CancellationToken ct = default)
    {
        return await _context.Inventories.FindAsync(id, ct);
    }
    public async Task<IEnumerable<Inventory>> GetAllAsync(CancellationToken ct = default)
    {
        return await _context.Inventories.ToListAsync(ct);
    }
    public async Task AddAsync(Inventory inventory, CancellationToken ct = default)
    {
        await _context.Inventories.AddAsync(inventory, ct);
    }
    public void Remove(Inventory inventory)
    {
        _context.Inventories.Remove(inventory);
    }

}