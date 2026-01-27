namespace RecreioBarcode.Application.UseCase.Inventories.Queries.ReadModels;

public sealed record InventoryDto
(
    int Id,
    string Name,
    bool IsActive
);