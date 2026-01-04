
namespace RecreioBarcode.Application.DTOs
{
    public class InventoryDTO
    {
        public int Id { get; private set; }
        public string Name { get; private set; } = string.Empty;
        public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;
        public DateTime FinishedAt { get; private set; }
        public bool IsClosed { get; private set; } = false;
        public string ChargerFilePath { get; private set; } = string.Empty;

        public ICollection<InventoryItemOutDTO> InventoryItemsOut { get; set; }
        public ICollection<InventoryLocationDTO> InventoryLocations { get; set; }
    }
}
