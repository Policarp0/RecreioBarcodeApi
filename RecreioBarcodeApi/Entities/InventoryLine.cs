namespace RecreioBarcodeApi.Entities
{
    public sealed class InventoryLine
    {
        public int Id { get; private set; }
        public string ItemCode { get; private set; } = string.Empty;
        public int CountedQuantity { get; private set; }

        public int InventoryId { get; set; }
        public Inventory Inventory { get; set;  }
        public int InventoryLocationId { get; set; }
        public InventoryLocation Location { get; set; }
    }
}