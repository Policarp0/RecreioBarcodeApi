using RecreioBarcode.Application.Common.Exceptions;
using RecreioBarcode.Domain.Interfaces;

namespace RecreioBarcode.Application.UseCase.Inventories.Queries.GetDetails;

public sealed class GetDetailsHandle(IInventoryRepository inventoryRepo)
{
    private readonly IInventoryRepository _inventoryRepo = inventoryRepo;

    public async Task<GetDetailsResult> Handle(GetDetailsQuery cmd, CancellationToken ct)
    {
        if (cmd.InventoryId <= 0)
            throw new UseCaseException("Inventory Id must be a positive value.");

        var inventory = await _inventoryRepo.GetSummaryByIdAsync(cmd.InventoryId, ct)
            ?? throw new UseCaseException("Inventory not found.");

        return new GetDetailsResult(
            inventory.Id,
            inventory.Name,
            inventory.CreatedAt,
            inventory.FinishedAt,
            inventory.Duration,
            inventory.IsActive,
            inventory.IsOpen,
            inventory.TotalLocations,
            inventory.TotalInventoriedLocations,
            inventory.TotalLines,
            inventory.TotalItemsOut
            );
    }
}
