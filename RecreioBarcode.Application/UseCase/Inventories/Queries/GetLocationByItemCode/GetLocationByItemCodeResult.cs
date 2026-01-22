namespace RecreioBarcode.Application.UseCase.Inventories.Queries.GetLocationByItemCode;

public sealed record GetLocationByItemCodeResult
(
    string LocationId,
    string LocationKey
);