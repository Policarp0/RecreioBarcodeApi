namespace RecreioBarcode.Application.UseCase.Inventories.CreateInventory;

public sealed record CreateInventoryFromCsvCommand
(
    string Name,
    Stream file
);