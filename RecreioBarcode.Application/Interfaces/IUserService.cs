using RecreioBarcode.Application.DTOs;
using RecreioBarcode.Domain.Entities;

namespace RecreioBarcode.Application.Interfaces
{
    public interface UserService : IService<UserDTO, int>
    {
        Task<IEnumerable<UserDTO>> GetAllAsync();
    }
}
