namespace RecreioBarcode.Application.UseCase.Inventories.Queries.ListInventoryLocations;

public sealed record InventoryLocationListItem(
    int InventoryLocationId,
    int LocationId,
    string Zona,
    int Rua,
    int Estante,
    string Prateleira,
    int Numero,
    bool IsInventoried,
    DateTime? InventoriedAt,
    int TotalLines
);