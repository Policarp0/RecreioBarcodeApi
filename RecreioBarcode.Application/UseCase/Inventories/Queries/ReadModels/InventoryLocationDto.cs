namespace RecreioBarcode.Application.UseCase.Inventories.Queries.ReadModels;

public sealed record InventoryLocationDto
(
    int Id,
    bool isInventoried,
    DateTime? InventoriedAt,
    int TotalLines,
    string LocationKey
);