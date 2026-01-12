
using System.ComponentModel.DataAnnotations;

namespace RecreioBarcode.Application.DTOs
{
    public class InventoryDTO
    {
        public int Id { get; set; }

        [MaxLength(100)]
        [Required]
        public string Name { get; set; } = string.Empty;
        public DateTime? CreatedAt { get; set; }
        public DateTime? FinishedAt { get; set; }
        public bool IsActive { get; set; } = false;

        [MaxLength(255)]
        [Required]
        public IFormFile? File { get; set; }
    }
}
