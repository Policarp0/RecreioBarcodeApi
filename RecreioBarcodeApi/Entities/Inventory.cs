
namespace RecreioBarcodeApi.Entities
{
    public class Inventory
    {
        public int Id { get; private set; }
        public string Name { get; private set; } = string.Empty;
        public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;
        public DateTime FinishedAt { get; private set; }
        public bool IsClosed { get; private set; } = false;
        public string ChargeArchivePath { get; private set; } = string.Empty;

        public ICollection<InventoryItemOut> InventoryItemsOut { get; set; }
        public ICollection<InventoryLine> InventoryLines { get; set; }
    }
}
