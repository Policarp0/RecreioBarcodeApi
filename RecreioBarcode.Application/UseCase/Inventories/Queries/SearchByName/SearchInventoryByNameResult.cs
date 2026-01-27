using RecreioBarcode.Application.UseCase.Inventories.Queries.ReadModels;

namespace RecreioBarcode.Application.UseCase.Inventories.Queries.SearchByName;

public sealed record SearchInventoryByNameResult(
    string Name,
    IReadOnlyList<InventoryDto> Items
);