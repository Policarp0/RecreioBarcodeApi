namespace RecreioBarcode.Application.UseCase.Inventories.Queries.ListInventoryLocations;

public sealed record ListInventoryLocationsQuery
(
    int InventoryId,
    bool? OnlyInventoried = null,      // null = todos
    string? Search = null              // opcional: filtrar por texto
);