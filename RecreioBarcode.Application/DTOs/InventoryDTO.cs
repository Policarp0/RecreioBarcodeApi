
using System.ComponentModel.DataAnnotations;

namespace RecreioBarcode.Application.DTOs
{
    public class InventoryDTO
    {
        [MaxLength(100)]
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        public DateTime? CreatedAt { get; set; }
        [Required]
        public DateTime? FinishedAt { get; set; }
        [Required]
        public bool IsClosed { get; set; } = false;
        [MaxLength(255)]
        [Required]
        public string ChargerFilePath { get; set; } = string.Empty;

    }
}
