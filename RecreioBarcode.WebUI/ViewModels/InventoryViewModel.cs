
using RecreioBarcode.Application.DTOs;

namespace RecreioBarcode.WebUI.ViewModel;

public class InventoryViewModel
{
    public string? Name {  get; set; }
    public IFormFile? File { get; set; }
    public IEnumerable<InventoryDTO> ActiveInventories { get; set; } = Enumerable.Empty<InventoryDTO>();
    public IEnumerable<InventoryDTO> InactiveInventories { get; set; } = Enumerable.Empty< InventoryDTO>();
}
