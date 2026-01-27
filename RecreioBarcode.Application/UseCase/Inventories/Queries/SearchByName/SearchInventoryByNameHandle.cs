using MediatR;
using RecreioBarcode.Application.Abstractions.Queries;
using RecreioBarcode.Application.Common.Exceptions;

namespace RecreioBarcode.Application.UseCase.Inventories.Queries.SearchByName;

public sealed class SearchInventoryByNameHandler(IInventoryReadQueries readQueries) : IRequestHandler<SearchInventoryByNameQuery, SearchInventoryByNameResult>
{
    private readonly IInventoryReadQueries _readQueries = readQueries;

    public async Task<SearchInventoryByNameResult> Handle(SearchInventoryByNameQuery query, CancellationToken ct)
    {
        var name = query.Name?.Trim();

        if (string.IsNullOrWhiteSpace(name))
            throw new UseCaseException("Name must be provided.");

        var take = query.Take <= 0 ? 20 : Math.Min(query.Take, 100);

        var items = await _readQueries.SearchByNameAsync(name, take, ct);

        return new SearchInventoryByNameResult(name, items);
    }
}