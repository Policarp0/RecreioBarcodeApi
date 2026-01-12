using RecreioBarcode.Domain.Entities;

namespace RecreioBarcode.Domain.Interfaces
{
    public interface ILocationRepository : IRepository<Location>
    {
        Task<Location?> GetByDetailsAsync(Location location);
    }
}
