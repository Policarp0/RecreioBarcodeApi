using RecreioBarcode.Domain.Entities;

namespace RecreioBarcode.Domain.Interfaces;

public interface ILocationRepository
{
    Task<Location?> GetByIdAsync(int id, CancellationToken ct = default);
    Task<Location?> GetByDetailsAsync(string zona, int rua, int estante, string prateleira, int numero, CancellationToken ct = default);
    Task AddAsync(Location location, CancellationToken ct = default);
}
