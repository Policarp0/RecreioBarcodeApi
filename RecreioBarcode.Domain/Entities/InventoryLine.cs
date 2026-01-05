namespace RecreioBarcode.Domain.Entities
{
    public sealed class InventoryLine
    {
        public int Id { get; private set; }
        public string ItemCode { get; private set; } = string.Empty;
        public int Count { get; private set; } = 0;

        public int InventoryLocationId { get; set; }             // Foreign key para InventoryLocation.
        public InventoryLocation InventoryLocation { get; set; } // Uma linha de inventário pertence a uma locação de inventário.

        public InventoryLine(string itemCode, int count)
        {
            Validate(itemCode, count);
        }
        public InventoryLine(int id, string itemCode, int count)
        {
            Id = id;
            Validate(itemCode, count);
        }
    
        public void Validate(string itemCode, int count)
        {
            ItemCode = itemCode;
            Count = count;
        }
        public void Update(string itemCode, int count, int inventoryId)
        {
            InventoryLocationId = inventoryId;
            Validate(itemCode, count);
        }
    }
}