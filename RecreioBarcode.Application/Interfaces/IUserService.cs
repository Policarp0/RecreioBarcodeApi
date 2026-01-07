using RecreioBarcode.Application.DTOs;

namespace RecreioBarcode.Application.Interfaces
{
    public interface IUserService : IService<UserDTO, int>
    {
        Task<IEnumerable<UserDTO>> GetAllAsync();
    }
}
