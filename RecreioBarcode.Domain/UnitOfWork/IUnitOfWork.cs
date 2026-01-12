using RecreioBarcode.Domain.Interfaces;

namespace RecreioBarcode.Domain.UnitOfWork
{
    public interface IUnitOfWork
    {
        IInventoryRepository InventoryRepository { get; }
        IInventoryLocationRepository InventoryLocationRepository{ get; }
        IInventoryLineRepository InventoryLineRepository { get; }
        IInventoryItemOutRepository InventoryItemOutRepository { get; }
        ILocationRepository LocationRepository { get; }
        IUserRepository UserRepository { get; }

        Task Commit();
        Task Dispose();
    }
}
