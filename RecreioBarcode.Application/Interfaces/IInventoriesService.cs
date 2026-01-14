using RecreioBarcode.Application.DTOs;
using RecreioBarcode.Domain.Entities;
using System.Linq.Expressions;

namespace RecreioBarcode.Application.Interfaces
{
    public interface IInventoryService
    {
        Task<InventoryDTO> GetByIdAsync(int id);
        Task<InventoryDTO> GetWhereAsync(Expression<Func<Inventory, bool>> predicate);
        Task<IEnumerable<InventoryDTO>> GetAllAsync();
        Task<IEnumerable<InventoryDTO>> GetAllWhereAsync(Expression<Func<Inventory, bool>> predicate);
        Task<InventoryDTO?> CreateFromCsvAsync(string name, Stream stream);
        Task<bool> UpdateAsync(int id, UpdateInventoryDTO dto);
        Task<bool> DeleteAsync(int id);
    }
}
