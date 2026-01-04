namespace RecreioBarcode.Domain.Entities
{
    public sealed class InventoryItemOut
    {
        public int Id { get; private set; }
        public string ItemCode { get; private set; } = string.Empty;
        public int CountedQuantity { get; private set; } = 1;

        public int InventoryId { get; set; }
        public Inventory Inventory { get; set; }
        public int LocationFoundId { get; set; }
        public Location LocationFound { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }

    }
}
