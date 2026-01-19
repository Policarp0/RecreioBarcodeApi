using RecreioBarcode.Application.UseCase.Inventories.CreateInventory;

namespace RecreioBarcode.Application.UseCase.Inventories.CreateInventoryFromCsv;

public interface ICreateInventoryFromCsv
{
    Task<CreateInventoryFromCsvResult> Handle(CreateInventoryFromCsvCommand cmd, CancellationToken ct);
}