
namespace RecreioBarcode.Application.DTOs
{
    public class InventoryDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime FinishedAt { get; set; }
        public bool IsClosed { get; set; } = false;
        public string ChargerFilePath { get; set; } = string.Empty;

    }
}
