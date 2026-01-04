using RecreioBarcode.Domain.Entities;

namespace RecreioBarcode.Domain.Interfaces
{
    public interface ILocationRepository
    {
        Task<Location?> GetByIdAsync(int id);
        Task<Location?> GetByDetailsAsync(char zona, int rua, int estante, char prateleira, int numero);

        Task<IEnumerable<Location>> GetAllAsync();

        Task<Location> CreateAsync(Location location);
        Task<Location> UpdateAsync(Location location);
        Task<Location> DeleteAsync(Location location);
    }
}
