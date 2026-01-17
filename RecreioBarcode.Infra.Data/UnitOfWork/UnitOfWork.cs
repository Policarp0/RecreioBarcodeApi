using RecreioBarcode.Domain.Interfaces;
using RecreioBarcode.Domain.UnitOfWork;
using RecreioBarcode.Infra.Data.Context;
using RecreioBarcode.Infra.Data.Repositories;

namespace RecreioBarcode.Infra.Data.UnitOfWork;

public class UnitOfWork(ApplicationContext context) : IUnitOfWork
{
    private readonly ApplicationContext _context = context;
    private IInventoryRepository? _inventoryRepository;
    private ILocationRepository? _locationRepository;

    public IInventoryRepository Inventories
    {
        get { return _inventoryRepository ??=  new InventoryRepository(_context); } 
    }
   
    public ILocationRepository Locations
    {
        get { return _locationRepository ??= new LocationRepository(_context); }
    }
    public async Task CommitAsync(CancellationToken ct = default)
    {
        await _context.SaveChangesAsync(ct);
    }
}
