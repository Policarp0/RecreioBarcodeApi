using RecreioBarcode.Domain.Entities;

namespace RecreioBarcode.Domain.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllAsync();

        Task<User> CreateAsync (User user);
        Task<User> UpdateAsync (User user);
        Task<User> DeleteAsync (User user);

        //public Task<User> GetConnectedUsersCountAsync();
        //public Task<bool> IsUserConnectedAsync(string userId);
        //public Task MarkUserAsConnectedAsync(string userId);
        //public Task MarkUserAsDisconnectedAsync(string userId);

    }
}
