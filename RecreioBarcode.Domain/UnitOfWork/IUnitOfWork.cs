using RecreioBarcode.Domain.Entities;
using RecreioBarcode.Domain.Interfaces;

namespace RecreioBarcode.Domain.UnitOfWork
{
    public interface IUnitOfWork
    {
        IInventoryRepository Inventories { get; }
        ILocationRepository Locations { get; }

        Task CommitAsync( CancellationToken ct = default);
    }
}
