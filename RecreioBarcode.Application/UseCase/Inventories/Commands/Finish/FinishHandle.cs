using RecreioBarcode.Application.Common.Exceptions;
using RecreioBarcode.Domain.Exceptions;
using RecreioBarcode.Domain.Interfaces;
using RecreioBarcode.Domain.UnitOfWork;

namespace RecreioBarcode.Application.UseCase.Inventories.Commands.Finish;

public sealed class FinishHandle(IInventoryRepository inventoryRepo, IUnitOfWork uow)
{
    private readonly IInventoryRepository _inventoryRepo = inventoryRepo;
    private readonly IUnitOfWork _uow = uow;

    public async Task Handle (FinishCommand cmd, CancellationToken ct)
    {
        if (cmd.InventoryId <= 0)
            throw new UseCaseException("Inventory Id must be a positive value");

        var inventory = await _inventoryRepo.GetSummaryByIdAsync(cmd.InventoryId, ct)
            ?? throw new UseCaseException("Inventory not found");

        inventory.Finish();
        await _uow.CommitAsync(ct);     
    }
}
