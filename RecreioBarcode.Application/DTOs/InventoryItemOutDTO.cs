using System.ComponentModel.DataAnnotations;

namespace RecreioBarcode.Application.DTOs
{
    public class InventoryItemOutDTO
    {
        public int Id { get; set; }

        [MaxLength(20)][Required]
        public string ItemCode { get; set; } = string.Empty;
        [Range(0,99_999)][Required]
        public int CountedQuantity { get; set; } = 0;

        public int InventoryId { get; set; }
        public InventoryDTO Inventory { get; set; } = null!;
        public int LocationId { get; set; }
        public LocationDTO Location{ get; set; } = null!;
        public int UserId { get; set; }
        public UserDTO User { get; set; } = null!;

    }
}
