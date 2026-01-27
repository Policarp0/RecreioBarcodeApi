using MediatR;
using RecreioBarcode.Application.Abstractions.Queries;
using RecreioBarcode.Application.Common.Exceptions;

namespace RecreioBarcode.Application.UseCase.Inventories.Queries.GetInventoryDetails;

public sealed class GetInventoryDetailsHandle(IInventoryReadQueries readQueries) : IRequestHandler<GetInventoryDetailsQuery, GetInventoryDetailsResult>
{
    private readonly IInventoryReadQueries _readQueries = readQueries;
    public async Task<GetInventoryDetailsResult> Handle(GetInventoryDetailsQuery query, CancellationToken ct)
    {
        if (query.InventoryId <= 0)
            throw new UseCaseException("Inventory Id must be a positive value.");

        var dto = await _readQueries.GetDetailsAsync(query.InventoryId, ct);

        if (dto is null)
            throw new UseCaseException($"Inventory {query.InventoryId} not found.");

        return new GetInventoryDetailsResult(dto);

    }
}
