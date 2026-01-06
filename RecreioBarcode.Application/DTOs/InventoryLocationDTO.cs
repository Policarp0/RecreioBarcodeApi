using RecreioBarcode.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace RecreioBarcode.Application.DTOs
{
    public sealed class InventoryLocationDTO
    {
        [Required]
        public bool IsInventoried { get; set; } = false;
        [Required]
        public DateTime? InventoriedAt { get; set; }
        [Required]
        public int InventoryId { get; set; }
        [Required]
        public int LocationId { get; set; }
        [Required]
        public int? UserId { get; set; }

    }
}