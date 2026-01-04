using RecreioBarcode.Domain.Entities;

namespace RecreioBarcode.Application.DTOs
{
    public sealed class InventoryLocationDTO
    {
        public int Id { get; set; }
        public bool IsInventoried { get; set; }
        public DateTime InventoriedAt { get; set; }

        public int InventoryId { get; set; }
        public InventoryDTO Inventory { get; set; }
        public int LocationId { get; set; }
        public LocationDTO Location { get; set; }
        public ICollection<InventoryLineDTO> InventoryLines { get; set; }
        public int UserId { get; set; }
        public UserDTO User { get; set; }
    }
}