namespace RecreioBarcode.Domain.Entities
{
    public sealed class InventoryLine
    {
        public int Id { get; private set; }
        public string ItemCode { get; private set; } = string.Empty;
        public int CountedQuantity { get; private set; } = 0;

        public int InventoryLocationId { get; set; }             // Foreign key para InventoryLocation.
        public InventoryLocation InventoryLocation { get; set; } // Uma linha de inventário pertence a uma locação de inventário.
    }
}