using RecreioBarcode.Application.Common.Exceptions;
using RecreioBarcode.Domain.Interfaces;
using RecreioBarcode.Domain.UnitOfWork;

namespace RecreioBarcode.Application.UseCase.Inventories.Commands.Delete;

public sealed class DeleteHandle(IInventoryRepository inventoryRepo, IUnitOfWork uow)
{
    private readonly IInventoryRepository _inventoryRepo = inventoryRepo;
    private readonly IUnitOfWork _uow = uow;
    public async Task Handler(DeleteCommand cmd, CancellationToken ct)
    {
        if (cmd == null)
            throw new UseCaseException("Delete command is required");
        if (cmd.Id <= 0)
            throw new UseCaseException("Id must be a positive value");

        var inventory = await _inventoryRepo.GetSummaryByIdAsync(cmd.Id, ct)
            ?? throw new UseCaseException($"Inventory Not Found");

         _inventoryRepo.Remove(inventory);
        await _uow.CommitAsync(ct);   
    }
}
