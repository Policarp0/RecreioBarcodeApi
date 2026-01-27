namespace RecreioBarcode.Application.UseCase.Inventories.Queries.ReadModels;

public sealed record InventoryDetailsDto
(
    int Id,
    string Name,
    DateTime CreatedAt,
    DateTime? FinishedAt,
    TimeSpan? Duration,
    bool IsActive,
    bool IsOpen,
    int TotalLocations,
    int TotalInventoriedLocations,
    int TotalLines,
    int TotalItemsOut
);