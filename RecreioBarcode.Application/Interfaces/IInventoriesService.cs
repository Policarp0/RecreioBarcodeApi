using RecreioBarcode.Application.DTOs;
using RecreioBarcode.Domain.Entities;
using System.Linq.Expressions;

namespace RecreioBarcode.Application.Interfaces
{
    public interface IInventoryService
    {
        Task<InventoryDTO> GetAsync(Expression<Func<Inventory, bool>> predicate);
        Task<IEnumerable<InventoryDTO>> GetAllAsync(Expression<Func<Inventory, bool>> predicate);
        Task<InventoryDTO> CreateFromCsvAsync(InventoryDTO dto);
        Task<bool> UpdateAsync(InventoryDTO dto);
        Task<bool> DeleteAsync(InventoryDTO dto);
    }
}
