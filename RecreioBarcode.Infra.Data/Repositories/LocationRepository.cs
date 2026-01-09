using Microsoft.EntityFrameworkCore;
using RecreioBarcode.Domain.Entities;
using RecreioBarcode.Domain.Interfaces;
using RecreioBarcode.Infra.Data.Context;

namespace RecreioBarcode.Infra.Data.Repositories
{
    public class LocationRepository : Repository<Location>, ILocationRepository
    {

        public LocationRepository(ApplicationContext context) : base(context) { }

        public async Task<Location?> GetByDetailsAsync(char zona, int rua, int estante, char prateleira, int numero)
        {
            return await _context.Locations
                .FirstOrDefaultAsync(x => x.Zona == zona &&
                                          x.Rua == rua &&
                                          x.Estante == estante &&
                                          x.Prateleira == prateleira &&
                                          x.Numero == numero);
        }
    }
}
