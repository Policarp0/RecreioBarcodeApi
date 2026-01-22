namespace RecreioBarcode.Application.UseCase.Inventories.Commands.Rename;

public sealed record RenameCommand
(
  int InventoryId,
  string NewName
);