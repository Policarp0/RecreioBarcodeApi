using RecreioBarcode.Application.Abstractions.Queries;
using RecreioBarcode.Application.Common.Exceptions;
using RecreioBarcode.Application.UseCase.Inventories.Queries.ReadModels;

namespace RecreioBarcode.Application.UseCase.Inventories.Queries.ListLinesByInventoryLocation;

public sealed class ListInventoryLinesByInventoryLocationHandler(IInventoryReadQueries readQueries)
{
    private readonly IInventoryReadQueries _readQueries = readQueries;

    public async Task<IReadOnlyList<InventoryLineDto>> Handle(
        ListInventoryLinesByInventoryLocationQuery query,
        CancellationToken ct)
    {
        if (query.InventoryId <= 0)
            throw new UseCaseException("InventoryId must be a positive value.");

        if (query.InventoryLocationId <= 0)
            throw new UseCaseException("InventoryLocationId must be a positive value.");

        return await _readQueries.ListInventoryLinesByInventoryLocationAsync(
            query.InventoryId,
            query.InventoryLocationId,
            ct);
    }
}