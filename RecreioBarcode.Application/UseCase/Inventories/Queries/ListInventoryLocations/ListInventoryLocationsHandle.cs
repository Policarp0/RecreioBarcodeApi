using RecreioBarcode.Application.Common.Exceptions;
using RecreioBarcode.Domain.Interfaces;

namespace RecreioBarcode.Application.UseCase.Inventories.Queries.ListInventoryLocations;

public sealed class ListInventoryLocationsHandler(IInventoryRepository inventoryRepo)
{
    private readonly IInventoryRepository _inventoryRepo = inventoryRepo;

    public async Task<ListInventoryLocationsResult> Handle(ListInventoryLocationsQuery query, CancellationToken ct)
    {
        if (query.InventoryId <= 0)
            throw new UseCaseException("Inventory Id must be a positive value.");

        var items = await _inventoryRepo.ListInventoryLocationsAsync(
            query.InventoryId,
            query.OnlyInventoried,
            query.Search,
            ct);

        return new ListInventoryLocationsResult(query.InventoryId, items);
    }
}
