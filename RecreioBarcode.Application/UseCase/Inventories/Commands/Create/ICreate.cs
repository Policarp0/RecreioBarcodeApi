namespace RecreioBarcode.Application.UseCase.Inventories.Commands.Create;

public interface ICreate
{
    Task<CreateResult> Handle(CreateCommand cmd, CancellationToken ct);
}