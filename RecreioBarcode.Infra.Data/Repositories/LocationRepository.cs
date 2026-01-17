using RecreioBarcode.Domain.Entities;
using RecreioBarcode.Domain.Interfaces;
using RecreioBarcode.Infra.Data.Context;

namespace RecreioBarcode.Infra.Data.Repositories;

public class LocationRepository(ApplicationContext context) : ILocationRepository
{
    private readonly ApplicationContext _context = context;

    public async Task<Location?> GetByIdAsync(int id, CancellationToken ct = default)
    {
        return await _context.Locations.FindAsync([id, ct], cancellationToken: ct);
    }
    public async Task AddAsync(Location location, CancellationToken ct = default)
    {
        await _context.Locations.AddAsync(location, ct);
    }
}
