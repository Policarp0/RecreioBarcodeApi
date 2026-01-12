using RecreioBarcode.Domain.Entities;
using RecreioBarcode.Domain.Interfaces;

namespace RecreioBarcode.Domain.UnitOfWork
{
    public interface IUnitOfWork
    {
        IRepository<Inventory> InventoryRepository { get; }
        IRepository<InventoryLocation> InventoryLocationRepository { get; }
        IRepository<InventoryLine> InventoryLineRepository { get; }
        IRepository<InventoryItemOut> InventoryItemOutRepository { get; }
        IRepository<Location> LocationRepository { get; }

        Task Commit();
        Task Dispose();
    }
}
