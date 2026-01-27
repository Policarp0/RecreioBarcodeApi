using MediatR;

namespace RecreioBarcode.Application.UseCase.Inventories.Queries.SearchByName;

public sealed record SearchInventoryByNameQuery(string Name, int Take = 20) : IRequest<SearchInventoryByNameResult>;