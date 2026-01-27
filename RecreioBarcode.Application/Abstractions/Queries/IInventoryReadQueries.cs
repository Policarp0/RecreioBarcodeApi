using RecreioBarcode.Application.UseCase.Inventories.Queries.ReadModels;

namespace RecreioBarcode.Application.Abstractions.Queries;

public interface IInventoryReadQueries
{
    Task<InventoryDetailsDto?> GetDetailsAsync(int inventoryId, CancellationToken ct);

    Task<IReadOnlyList<InventoryLocationDto>> ListInventoryLocationsAsync(
        int inventoryId,
        bool? onlyInventoried,
        CancellationToken ct);

    Task<IReadOnlyList<InventoryLineDto>> ListInventoryLinesByInventoryLocationAsync(
        int inventoryId,
        int inventoryLocationId,
        CancellationToken ct);

    Task<IReadOnlyList<InventoryDto>> SearchByNameAsync(
        string name,
        int take,
        CancellationToken ct);
}