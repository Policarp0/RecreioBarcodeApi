using System.ComponentModel.DataAnnotations;

namespace RecreioBarcode.Application.DTOs
{ 
    public sealed class InventoryLineDTO
    {
        [MaxLength(20)]
        [Required]
        public string ItemCode { get; set; } = string.Empty;
        [Range(0, 99_999)]
        [Required]
        public int CountedQuantity { get; set; }

        [Required]
        public int InventoryLocationId { get; set; }
    }
}