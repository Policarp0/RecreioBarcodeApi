using RecreioBarcode.Application.UseCase.Inventories.Queries.ReadModels;

namespace RecreioBarcode.Application.UseCase.Inventories.Queries.GetInventoryDetails;

public sealed record GetInventoryDetailsResult(InventoryDetailsDto Inventory);
