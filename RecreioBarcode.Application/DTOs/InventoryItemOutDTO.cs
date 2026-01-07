using System.ComponentModel.DataAnnotations;

namespace RecreioBarcode.Application.DTOs
{
    public class InventoryItemOutDTO
    {
        public int Id { get; set; }
        [MaxLength(20)] 
        [Required]
        public string ItemCode { get; set; } = string.Empty;
        [Range(0,99_999)]
        [Required]
        public int CountedQuantity { get; set; } = 0;
        [Required]
        public int InventoryId { get; set; }
        [Required]
        public int LocationFoundId { get; set; }
        [Required]
        public int UserId { get; set; }

    }
}
