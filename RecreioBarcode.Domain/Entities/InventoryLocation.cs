namespace RecreioBarcode.Domain.Entities
{
    public sealed class InventoryLocation
    {
        public int Id { get; private set; }
        public bool IsInventoried { get; private set; } = false;
        public DateTime InventoriedAt { get; private set; }

        public int InventoryId { get; set; }
        public Inventory Inventory { get; set; }
        public int LocationId { get; set; }
        public Location Location { get; set; }
        public ICollection<InventoryLine> InventoryLines { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}