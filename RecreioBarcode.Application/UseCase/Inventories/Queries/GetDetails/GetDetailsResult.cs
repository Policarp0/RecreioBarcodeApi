namespace RecreioBarcode.Application.UseCase.Inventories.Queries.GetDetails;

public sealed record GetDetailsResult
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
