using RecreioBarcode.Domain.Entities;

namespace RecreioBarcode.Application.DTOs
{
    public sealed class InventoryLocationDTO
    {
        public int Id { get; private set; }
        public bool IsInventoried { get; private set; }
        public DateTime InventoriedAt { get; private set; }

        public int InventoryId { get; set; }
        public Inventory Inventory { get; set; }
        public int LocationId { get; set; }
        public LocationDTO Location { get; set; }
        public ICollection<InventoryLineDTO> InventoryLines { get; set; }
        public int UserId { get; set; }
        public UserDTO User { get; set; }
    }
}