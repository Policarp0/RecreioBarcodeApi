using MediatR;

namespace RecreioBarcode.Application.UseCase.Inventories.Queries.GetInventoryDetails;

public sealed record GetInventoryDetailsQuery (int InventoryId) : IRequest<GetInventoryDetailsResult> ;