namespace RecreioBarcode.Application.UseCase.Inventories.Queries.ListInventoryLocations;

public sealed record ListInventoryLocationsResult(
    int InventoryId,
    IReadOnlyList<InventoryLocationListItem> Items
);
