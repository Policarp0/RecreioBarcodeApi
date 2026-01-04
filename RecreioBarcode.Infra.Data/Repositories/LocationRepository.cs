using Microsoft.EntityFrameworkCore;
using RecreioBarcode.Domain.Entities;
using RecreioBarcode.Domain.Interfaces;
using RecreioBarcode.Infra.Data.Context;

namespace RecreioBarcode.Infra.Data.Repositories
{
    public class LocationRepository : ILocationRepository
    {
        private readonly ApplicationContext _context;
        public LocationRepository(ApplicationContext context){ _context = context; }

        public async Task<Location> CreateAsync(Location location)
        {
            await _context.Locations.AddAsync(location);
            return location;
        }

        public async Task<Location> DeleteAsync(Location location)
        {
            _context.Remove(location);
            await _context.SaveChangesAsync();
            return location;
        }

        public async Task<IEnumerable<Location>> GetAllAsync()
        {
            return await _context.Locations.ToListAsync();
        }

        public async Task<Location?> GetByDetailsAsync(char zona, int rua, int estante, char prateleira, int numero)
        {
            return await _context.Locations
                .FirstOrDefaultAsync(x => x.Zona == zona &&
                                          x.Rua == rua &&
                                          x.Estante == estante &&
                                          x.Prateleira == prateleira &&
                                          x.Numero == numero);
        }

        public async Task<Location?> GetByIdAsync(int id)
        {
            return await _context.Locations.FindAsync(id);
        }

        public async Task<Location> UpdateAsync(Location location)
        {
            _context.Locations.Update(location);
            await _context.SaveChangesAsync();
            return location;
        }
    }
}
