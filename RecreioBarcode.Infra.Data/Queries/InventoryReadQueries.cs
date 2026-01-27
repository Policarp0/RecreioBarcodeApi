using Microsoft.EntityFrameworkCore;
using RecreioBarcode.Application.Abstractions.Queries;
using RecreioBarcode.Application.UseCase.Inventories.Queries.ReadModels;
using RecreioBarcode.Infra.Data.Context;

namespace RecreioBarcode.Infra.Data.Queries;

public sealed class InventoryReadQueries(ApplicationContext context) : IInventoryReadQueries
{
    private readonly ApplicationContext _context = context;

    public async Task<InventoryDetailsDto?> GetDetailsAsync(int inventoryId, CancellationToken ct)
    {
        return await _context.Inventories
            .AsNoTracking()
            .Where(i => i.Id == inventoryId)
            .Select(i => new InventoryDetailsDto(
                i.Id,
                i.Name,
                i.CreatedAt,
                i.FinishedAt,
                i.Duration,
                i.IsActive,
                i.IsOpen,
                i.TotalLocations,
                i.TotalInventoriedLocations,
                i.TotalLines,
                i.TotalItemsOut
            ))
            .FirstOrDefaultAsync(ct);
    }

    public async Task<IReadOnlyList<InventoryLocationDto>> ListInventoryLocationsAsync(
        int inventoryId,
        bool? onlyInventoried,
        CancellationToken ct)
    {
        var query = _context.InventoryLocations
            .AsNoTracking()
            .Where(il => il.InventoryId == inventoryId);

        if (onlyInventoried.HasValue)
            query = query.Where(il => il.IsInventoried == onlyInventoried.Value);

        return await query
            .OrderBy(il => il.Id)
            .Select(il => new InventoryLocationDto(il.Id, il.IsInventoried, il.InventoriedAt, il.TotalLines, il.Location.Key))
            .ToListAsync(ct);
    }

    public async Task<IReadOnlyList<InventoryLineDto>> ListInventoryLinesByInventoryLocationAsync(
        int inventoryId,
        int inventoryLocationId,
        CancellationToken ct)
    {
        return await _context.InventoryLines
            .AsNoTracking()
            .Where(l =>
                l.InventoryLocationId == inventoryLocationId &&
                l.InventoryLocation.InventoryId == inventoryId)
            .OrderBy(l => l.Id)
            .Select(l => new InventoryLineDto(
                l.Id,
                l.ItemCode,
                l.Count
            ))
            .ToListAsync(ct);
    }

    public async Task<IReadOnlyList<InventoryDto>> SearchByNameAsync(
       string name,
       int take,
       CancellationToken ct)
    {
        name = name.Trim();

        return await _context.Inventories
            .AsNoTracking()
            .Where(i => EF.Functions.Like(i.Name, $"%{name}%"))
            .OrderBy(i => i.Name)
            .Take(take)
            .Select(i => new InventoryDto(
                i.Id,
                i.Name,
                i.IsActive
            ))
            .ToListAsync(ct);
    }
}