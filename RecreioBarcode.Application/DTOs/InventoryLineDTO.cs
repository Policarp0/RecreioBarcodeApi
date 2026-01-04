namespace RecreioBarcode.Application.DTOs
{ 
    public sealed class InventoryLineDTO
    {
        public int Id { get; private set; }
        public string ItemCode { get; private set; } = string.Empty;
        public int CountedQuantity { get; private set; }

        public int InventoryLocationId { get; set; }
        public InventoryLocationDTO Location { get; set; }
    }
}