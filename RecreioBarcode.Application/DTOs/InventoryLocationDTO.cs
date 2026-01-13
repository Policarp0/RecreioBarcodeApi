using RecreioBarcode.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace RecreioBarcode.Application.DTOs
{
    public class InventoryLocationDTO
    {
        public int Id { get; set; }
        public bool IsInventoried { get; set; } = false;
        public DateTime? InventoriedAt { get; set; } = null;
        public int InventoryId { get; set; }
        public InventoryDTO Inventory { get; set; } = null!;
        public int LocationId { get; set; }
        public LocationDTO Location{ get; set; } = null!;
    }
}