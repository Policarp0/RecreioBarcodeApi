using RecreioBarcode.Application.DTOs;
using RecreioBarcode.Domain.Entities;

namespace RecreioBarcode.Application.Interfaces
{
    public interface LocationService : IService<LocationDTO, int>
    {
        Task<LocationDTO?> GetByDetailsAsync(char zona, int rua, int estante, char prateleira, int numero);
        Task<IEnumerable<LocationDTO>> GetAllAsync();
    }
}
