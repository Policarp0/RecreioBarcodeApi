using RecreioBarcode.Application.Common.Exceptions;
using RecreioBarcode.Domain.Interfaces;
using RecreioBarcode.Domain.UnitOfWork;

namespace RecreioBarcode.Application.UseCase.Inventories.Commands.Rename;

public sealed class RenameHandler(IInventoryRepository inventoryRepo, IUnitOfWork uow)
{
    private readonly IInventoryRepository _inventoryRepo = inventoryRepo;
    private readonly IUnitOfWork _uow = uow;

    public async Task Handle(RenameCommand cmd, CancellationToken ct)
    {
        if (cmd.InventoryId <= 0)
            throw new UseCaseException("Inventory Id must be a positive value");

        var inventory = await _inventoryRepo.GetSummaryByIdAsync(cmd.InventoryId, ct)
            ?? throw new UseCaseException("Inventory not found");

        inventory.ChangeName(cmd.NewName);
        await _uow.CommitAsync(ct);
    }
}
