using RecreioBarcode.Application.UseCase.Locations.CreateLocation;
using RecreioBarcode.Domain.Entities;
using RecreioBarcode.Domain.Interfaces;

namespace RecreioBarcode.Application.UseCase.Inventories.CreateInventory;

public class CreateInventoryFromCsvHandler(IInventoryRepository inventoryRepo, ILocationRepository locationRepo)
{
    private readonly IInventoryRepository _inventoryRepo = inventoryRepo;
    private readonly ILocationRepository _locationRepo = locationRepo;

    public async Task<CreateInventoryFromCsvCommand>Handle(CreateInventoryFromCsvCommand cmd, CancellationToken ct)
    {
        if(string.IsNullOrWhiteSpace(cmd.Name))
            throw new ArgumentNullException("Name is required.");

        var inventory = new Inventory(cmd.Name);

        StreamReader reader = new(cmd.file);
        reader.ReadLine(); // Pula a primeira linha
        var line = reader.ReadLine();

        while (line != ";")
        {
            if (line == null)
                throw new ArgumentException("Read line error");
            if (line.Count(c => c == ';') != 1)
                throw new ArgumentException("Line don't have two columns");

            var input = line.Split(';'); // [0] é código, [1] é locação

            if (input[0].Length > 14)
                throw new ArgumentException("Error read line input[0]");
            if (input[1].Length > 11)
                throw new ArgumentException("Error read line input[1]");

            var location = await GetOrCreateLocation(input[1], ct);
            if (!inventory.ExistLocation(location))
                inventory.AddLocation(location);

            inventory.
            

    }

    private async Task<Location> GetOrCreateLocation (string input, CancellationToken ct)
    {
        if (!int.TryParse(input.Substring(1, 2).Trim(), out int rua))
            throw new ArgumentException("Erro parsing rua.");

        if (!int.TryParse(input.Substring(3, 3).Trim(), out int estante))
            throw new ArgumentException("Erro parsing estante.");

        if (!int.TryParse(input.Substring(7, 3).Trim(), out int numero))
            throw new ArgumentException("Erro parsing numero.");
            
        var zona = input.Substring(0, 1).Trim();
        
        var prateleira = input.Substring(6, 1).Trim();

        var location = await _locationRepo.GetByDetailsAsync(zona, rua, estante, prateleira, numero, ct);
        if (location is not null)
            return location;
        else
        {
            location = new Location(zona, rua, estante, prateleira, numero);
            await _locationRepo.AddAsync(location, ct);
            return location;
        }
    }
}
