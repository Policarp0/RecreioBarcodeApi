using RecreioBarcode.Application.Common.Exceptions;
using RecreioBarcode.Application.UseCase.Inventories.Queries.GetDetails;
using RecreioBarcode.Domain.Interfaces;

namespace RecreioBarcode.Application.UseCase.Inventories.Queries.GetLocationByItemCode;

public sealed class GetLocationByItemCodeHandle(IInventoryRepository inventoryRepo)
{
    private readonly IInventoryRepository _inventoryRepo = inventoryRepo;

    public async Task<GetLocationByItemCodeResult> Handle(GetLocationByItemCodeQuery query, CancellationToken ct)
    {
        if (query.InventoryId <= 0)
            throw new UseCaseException("Inventory Id must be a positive value.");
        if (string.IsNullOrWhiteSpace(query.ItemCode))
            throw new UseCaseException("Item code is required.");

        var inventory = await _inventoryRepo.GetByIdAsync(query.InventoryId)
            ?? throw new UseCaseException("Inventory not found.");
        
        
    }
}