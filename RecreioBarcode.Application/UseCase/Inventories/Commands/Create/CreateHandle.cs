using RecreioBarcode.Domain.Entities;
using RecreioBarcode.Domain.Exceptions;
using RecreioBarcode.Domain.Interfaces;
using RecreioBarcode.Domain.UnitOfWork;

namespace RecreioBarcode.Application.UseCase.Inventories.Commands.Create;

public sealed class CreateHandle
    (IUnitOfWork uow,
    ILocationRepository locationRepo,
    IInventoryRepository inventoryRepo)
{
    private readonly IUnitOfWork _uow = uow;
    private readonly ILocationRepository _locationRepo = locationRepo;
    private readonly IInventoryRepository _inventoryRepo = inventoryRepo;
    private readonly Dictionary<string, Location> _locationCache = new(StringComparer.OrdinalIgnoreCase);

    public async Task<CreateResult> Handle(CreateCommand cmd, CancellationToken ct)
    {
        if (string.IsNullOrWhiteSpace(cmd.Name))
            throw new ArgumentNullException("Name is required.");

        var inventory = new Inventory(cmd.Name);

        using StreamReader reader = new(cmd.file);

        await reader.ReadLineAsync(); // Pula a primeira linha

        int lineNumber = 0; 
        string? line;
        while ((line = await reader.ReadLineAsync()) is not null)
        {
            lineNumber++;
            if (line == ";") break;
            if (line.Length == 0) continue;

            try
            {
                if (line == null)
                    throw new ArgumentException("Read line error");
                if (line.Count(c => c == ';') != 1)
                    throw new ArgumentException("Line don't have two columns");

                var input = line.Split(';'); // [0] é código, [1] é locação

                if (input[1].Length > 11)
                    throw new ArgumentException("Error read line input[1]");

                var location = await GetOrCreateLocation(input[1], ct);
                var inventoryLocation = inventory.GetOrAddInventoryLocation(location);
                var inventoryLine = inventory.GetOrAddInventoryLine(input[0], location);
            }
            catch (DomainException ex)
            {
                throw new DomainException(
                    $"CSV inválido na linha {lineNumber}. Conteúdo: '{line}'. Erro: {ex.Message}"
                    );
            }

        }
        await _inventoryRepo.AddAsync(inventory);
        await _uow.CommitAsync(ct);
        return new CreateResult(inventory.Id);
    }
    private async Task<Location> GetOrCreateLocation(string input, CancellationToken ct)
    {
        if (!int.TryParse(input.Substring(1, 2).Trim(), out int rua))
            throw new ArgumentException("Erro parsing rua.");
        if (!int.TryParse(input.Substring(3, 3).Trim(), out int estante))
            throw new ArgumentException("Erro parsing estante.");
        if (!int.TryParse(input.Substring(7, 3).Trim(), out int numero))
            throw new ArgumentException("Erro parsing numero.");
        var zona = input.Substring(0, 1).Trim();
        var prateleira = input.Substring(6, 1).Trim();

        var key = $"{zona}-{rua}-{estante}-{prateleira}-{numero}";

        if (_locationCache.TryGetValue(key, out var cached))
            return cached;

        var location = await _locationRepo.GetByDetailsAsync(zona, rua, estante, prateleira, numero, ct);

        if (location is null)
        {
            location = new Location(zona, rua, estante, prateleira, numero);
            await _locationRepo.AddAsync(location, ct);
        }

            _locationCache[key] = location;
            return location;
    }
}
