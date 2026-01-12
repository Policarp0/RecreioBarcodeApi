using RecreioBarcode.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace RecreioBarcode.Application.DTOs
{
    public class InventoryLocationDTO
    {
        public int Id { get; set; }
        [Required]
        public bool IsInventoried { get; set; } = false;
        [Required]
        public DateTime? InventoriedAt { get; set; }
        [Required]
        public int InventoryId { get; set; }
        public InventoryDTO Inventory { get; set; } = null!;
        [Required]
        public int LocationId { get; set; }
        public LocationDTO Location{ get; set; } = null!;
        [Required]
        public int? UserId { get; set; }
        public UserDTO User { get; set; } = null!;

    }
}