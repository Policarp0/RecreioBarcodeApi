using Microsoft.EntityFrameworkCore;
using RecreioBarcode.Domain.Entities;
using RecreioBarcode.Domain.Interfaces;
using RecreioBarcode.Infra.Data.Context;

namespace RecreioBarcode.Infra.Data.Repositories
{
    public class InventoryLocationRepository : Repository<InventoryLocation>, IInventoryLocationRepository
    {
        public InventoryLocationRepository(ApplicationContext context) : base(context) { }

        public async Task<IEnumerable<InventoryLocation>> GetAllByEstanteAsync(int inventoryId, char estante)
        {
            return await _context.InventoryLocations.Where(x => x.InventoryId == inventoryId && x.Location.Estante == estante).ToListAsync();
        }
        public async Task<IEnumerable<InventoryLocation>> GetAllByNumeroAsync(int inventoryId, char numero)
        {
            return await _context.InventoryLocations.Where(x => x.InventoryId == inventoryId && x.Location.Numero == numero).ToListAsync();
        }
        public async Task<IEnumerable<InventoryLocation>> GetAllByPrateleiraAsync(int inventoryId, char prateleira)
        {
            return await _context.InventoryLocations.Where(x => x.InventoryId == inventoryId && x.Location.Prateleira == prateleira).ToListAsync();
        }
        public async Task<IEnumerable<InventoryLocation>> GetAllByRuaAsync(int inventoryId, char rua)
        {
            return await _context.InventoryLocations.Where(x => x.InventoryId == inventoryId && x.Location.Rua == rua).ToListAsync();
        }
        public async Task<IEnumerable<InventoryLocation>> GetAllByZonaAsync(int inventoryId, char zona)
        {
            return await _context.InventoryLocations.Where(x => x.InventoryId == inventoryId && x.Location.Zona == zona).ToListAsync();
        }
        public async Task<IEnumerable<InventoryLocation>> GetAllByInventoryIdAsync(int inventoryId)
        {
            return await _context.InventoryLocations.Where(x => x.InventoryId == inventoryId).ToListAsync();
        }
    }
}
