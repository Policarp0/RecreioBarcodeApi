using RecreioBarcode.Domain.Entities;

namespace RecreioBarcode.Domain.Interfaces
{
    public interface ILocationRepository
    {
        Task<Location> GetById(int id);
        Task<Location> GetByDetails(char zona, int rua, int estante, char prateleira, int numero);

        Task<IEnumerable<Location>> GetAll();

        Task<Location> Create(Location location);
        Task<Location> Update(Location location);
        Task<Location> Delete(int id);
    }
}
