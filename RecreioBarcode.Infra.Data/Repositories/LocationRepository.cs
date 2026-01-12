using Microsoft.EntityFrameworkCore;
using RecreioBarcode.Domain.Entities;
using RecreioBarcode.Domain.Interfaces;
using RecreioBarcode.Infra.Data.Context;

namespace RecreioBarcode.Infra.Data.Repositories
{
    public class LocationRepository : Repository<Location>, ILocationRepository
    {

        public LocationRepository(ApplicationContext context) : base(context) { }

        public async Task<Location?> GetByDetailsAsync(Location location)
        {
            return await _context.Locations
                .FirstOrDefaultAsync(x => x.Zona == location.Zona &&
                                          x.Rua == location.Rua &&
                                          x.Estante == location.Estante &&
                                          x.Prateleira == location.Prateleira &&
                                          x.Numero == location.Numero);
        }
    }
}
