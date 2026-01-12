using RecreioBarcode.Application.DTOs;

namespace RecreioBarcode.Application.Interfaces
{
    public interface ILocationService
    {
        Task<LocationDTO?> GetByDetailsAsync(char zona, int rua, int estante, char prateleira, int numero);
        Task<IEnumerable<LocationDTO>> GetAllAsync();
    }
}
