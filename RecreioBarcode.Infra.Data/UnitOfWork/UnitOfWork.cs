using RecreioBarcode.Domain.Interfaces;
using RecreioBarcode.Infra.Data.Context;
using RecreioBarcode.Infra.Data.Repositories;

namespace RecreioBarcode.Infra.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private IInventoryRepository _inventoryRepository;
        private IInventoryLineRepository _inventoryLineRepository;
        private IInventoryLocationRepository _inventoryLocationRepository;
        private IInventoryItemOutRepository _inventoryItemOutRepository;
        private ILocationRepository _locationRepository;
        private IUserRepository _userRepository;

        public ApplicationContext _context;

        public UnitOfWork(
            IInventoryRepository inventoryRepository, 
            IInventoryLineRepository inventoryLineRepository, 
            IInventoryLocationRepository inventoryLocationRepository, 
            IInventoryItemOutRepository inventoryItemOutRepository, 
            ILocationRepository locationRepository, 
            IUserRepository userRepository, 
            ApplicationContext context)
        {
            _context = context;
        }

        public IInventoryRepository InventoryRepository
        {
            get { return _inventoryRepository ??  new InventoryRepository(_context); } 
        }
        public IInventoryLocationRepository InventoryLocationRepository
        {
            get { return _inventoryLocationRepository ?? new InventoryLocationRepository(_context); }
        }
        public IInventoryLineRepository InventoryLineRepository
        {
            get { return _inventoryLineRepository ?? new InventoryLineRepository(_context); }
        }
        public IInventoryItemOutRepository InventoryItemOutRepository
        {
            get { return _inventoryItemOutRepository ?? new InventoryItemOutRepository(_context); }
        }
        public ILocationRepository LocationRepository
        {
            get { return _locationRepository ?? new LocationRepository(_context); }
        }
        public IUserRepository UserRepository
        {
            get { return _userRepository ?? new UserRepository(_context); }
        }
        public void Commit()
        {
            _context.SaveChanges();
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
