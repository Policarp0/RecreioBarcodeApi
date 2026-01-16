using RecreioBarcode.Domain.Entities;
using RecreioBarcode.Domain.Interfaces;
using RecreioBarcode.Domain.UnitOfWork;
using RecreioBarcode.Infra.Data.Context;
using RecreioBarcode.Infra.Data.Repositories;

namespace RecreioBarcode.Infra.Data.UnitOfWork;

public class UnitOfWork : IUnitOfWork
{
    private IRepository<Inventory>? _inventoryRepository;
    private IRepository<InventoryLine>? _inventoryLineRepository;
    private IRepository<InventoryLocation>? _inventoryLocationRepository;
    private IRepository<InventoryItemOut>? _inventoryItemOutRepository;
    private IRepository<Location>? _locationRepository;

    public ApplicationContext _context;

    public UnitOfWork(ApplicationContext context)
    {
        _context = context;
    }

    public IRepository<Inventory> InventoryRepository
    {
        get { return _inventoryRepository ??=  new Repository<Inventory>(_context); } 
    }
    public IRepository<InventoryLocation> InventoryLocationRepository
    {
        get { return _inventoryLocationRepository ??= new Repository<InventoryLocation>(_context); }
    }
    public IRepository<InventoryLine> InventoryLineRepository
    {
        get { return _inventoryLineRepository ??= new Repository<InventoryLine>(_context); }
    }
    public IRepository<InventoryItemOut> InventoryItemOutRepository
    {
        get { return _inventoryItemOutRepository ??= new Repository<InventoryItemOut>(_context); }
    }
    public IRepository<Location> LocationRepository
    {
        get { return _locationRepository ??= new Repository<Location>(_context); }
    }
    public async Task Commit()
    {
        await _context.SaveChangesAsync();
    }
}
