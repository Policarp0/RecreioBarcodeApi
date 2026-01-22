namespace RecreioBarcode.Application.UseCase.Inventories.Queries.GetLocationByItemCode;

public sealed record GetLocationByItemCodeQuery
(
    int InventoryId,
    string ItemCode
);