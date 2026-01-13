using System.ComponentModel.DataAnnotations;

namespace RecreioBarcode.Application.DTOs;

public class UpdateInventoryDTO
{
    public string? Name { get; set; } 
    public bool? IsActive { get; set; } 
    public bool? ItStarted { get; set; }
}
