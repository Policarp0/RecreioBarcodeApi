using RecreioBarcode.Domain.Entities;

namespace RecreioBarcode.Domain.Interfaces
{
    public interface IUserRepository
    {
        public Task<User> GetAllAsync();

        //public Task<User> GetConnectedUsersCountAsync();
        //public Task<bool> IsUserConnectedAsync(string userId);
        //public Task MarkUserAsConnectedAsync(string userId);
        //public Task MarkUserAsDisconnectedAsync(string userId);

    }
}
