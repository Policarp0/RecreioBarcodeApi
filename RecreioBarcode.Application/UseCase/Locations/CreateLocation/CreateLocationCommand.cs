namespace RecreioBarcode.Application.UseCase.Locations.CreateLocation;

public sealed record CreateLocationCommand
(
    string Zona,
    int Rua,
    int Estante,
    string Prateleira,
    int Numero
);
