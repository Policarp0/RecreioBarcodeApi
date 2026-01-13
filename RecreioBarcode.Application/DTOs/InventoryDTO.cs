
using System.ComponentModel.DataAnnotations;

namespace RecreioBarcode.Application.DTOs
{
    public class InventoryDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateTime? CreatedAt { get; set; }
        public DateTime? FinishedAt { get; set; }
        public bool IsActive { get; set; }
        public bool ItStarted { get; set; } 
    }
}
