using Microsoft.EntityFrameworkCore;
using RecreioBarcode.Domain.Entities;
using RecreioBarcode.Domain.Interfaces;
using RecreioBarcode.Infra.Data.Context;

namespace RecreioBarcode.Infra.Data.Repositories
{
    public class InventoryLocationRepository : IInventoryLocationRepository
    {
        private readonly ApplicationContext _context;
        public InventoryLocationRepository(ApplicationContext context) { _context = context; }

        public async Task<InventoryLocation> CreateAsync(InventoryLocation inventoryLocation)
        {
            _context.InventoryLocations.Add(inventoryLocation);
            await _context.SaveChangesAsync();
            return inventoryLocation;
        }

        public async Task<InventoryLocation> DeleteAsync(InventoryLocation inventoryLocation)
        {
            _context.InventoryLocations.Remove(inventoryLocation);
            await _context.SaveChangesAsync();
            return inventoryLocation;
        }

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

        public async Task<InventoryLocation?> GetByInventoryIdAsync(int id)
        {
            return await _context.InventoryLocations.FindAsync(id);
        }

        public async Task<InventoryLocation> UpdateAsync(InventoryLocation inventoryLocation)
        {
            _context.InventoryLocations.Update(inventoryLocation);
            await _context.SaveChangesAsync();
            return inventoryLocation;
        }
    }
}
