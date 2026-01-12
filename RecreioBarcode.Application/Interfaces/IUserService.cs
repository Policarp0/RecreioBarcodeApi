using RecreioBarcode.Application.DTOs;

namespace RecreioBarcode.Application.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<UserDTO>> GetAllAsync();
    }
}
