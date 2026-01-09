using RecreioBarcode.Domain.Entities;

namespace RecreioBarcode.Domain.Interfaces
{
    public interface IInventoryRepository : IRepository<Inventory>
    {
        Task<IEnumerable<Inventory>> GetAllActiveAsync();
        Task<IEnumerable<Inventory>> GetAllInactiveAsync();
    }
}
