using RecreioBarcode.Domain.Entities;

namespace RecreioBarcode.Application.UseCase.Inventories.Queries.ReadModels;

public sealed record InventoryLineDto
(
    int Id,
    string ItemCode,
    int Count
);