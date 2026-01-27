using RecreioBarcode.Application.Abstractions.Queries;
using RecreioBarcode.Application.Common.Exceptions;
using RecreioBarcode.Application.UseCase.Inventories.Queries.ReadModels;

namespace RecreioBarcode.Application.UseCase.Inventories.Queries.ListInventoryLocations;

public sealed class ListInventoryLocationsHandler(IInventoryReadQueries readQueries)
{
    private readonly IInventoryReadQueries _readQueries = readQueries;

    public async Task<IReadOnlyList<InventoryLocationDto>> Handle(
        ListInventoryLocationsQuery query,
        CancellationToken ct)
    {
        if (query.InventoryId <= 0)
            throw new UseCaseException("InventoryId must be a positive value.");

        return await _readQueries.ListInventoryLocationsAsync(
            query.InventoryId,
            query.OnlyInventoried,
            ct);
    }
}
