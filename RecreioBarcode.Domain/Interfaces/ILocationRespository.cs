using RecreioBarcode.Domain.Entities;

namespace RecreioBarcode.Domain.Interfaces
{
    public interface ILocationRepository : IRepository<Location>
    {
        Task<Location?> GetByDetailsAsync(char zona, int rua, int estante, char prateleira, int numero);
    }
}
