namespace RecreioBarcode.Application.UseCase.Inventories.Commands.Create;

public sealed record CreateCommand
(
    string Name,
    Stream file
);