using RecreioBarcode.Domain.Entities;

namespace RecreioBarcode.Domain.Interfaces;

public interface IInventoryRepository
{
    Task<Inventory?> GetByIdAsync(int id, CancellationToken ct = default);
    Task<Inventory?> GetSummaryByIdAsync(int id, CancellationToken ct = default);
    Task AddAsync(Inventory inventory, CancellationToken ct = default);
}