using RecreioBarcode.Domain.Entities;
using RecreioBarcode.Domain.Interfaces;
using RecreioBarcode.Domain.UnitOfWork;

namespace RecreioBarcode.Application.UseCase.Locations.CreateLocation;

public sealed class CreateLocationHandler(ILocationRepository repo, IUnitOfWork uow)
{
    private readonly ILocationRepository _repo = repo;
    private readonly IUnitOfWork _uow = uow;

    public async Task<CreateLocationResult>Handle(CreateLocationCommand cmd, CancellationToken ct)
    {
        if (string.IsNullOrWhiteSpace(cmd.Zona))
            throw new ArgumentException("Zona is required.");
        if (string.IsNullOrWhiteSpace(cmd.Prateleira))
            throw new ArgumentException("Prateleira is required.");

        var location = new Location(cmd.Zona, cmd.Rua, cmd.Estante, cmd.Prateleira, cmd.Numero);
        await _repo.AddAsync(location, ct);
        await _uow.CommitAsync(ct);

        return new CreateLocationResult(location.Id);
    }
}