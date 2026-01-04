namespace RecreioBarcode.Application.DTOs
{ 
    public sealed class InventoryLineDTO
    {
        public int Id { get;  set; }
        public string ItemCode { get; set; } = string.Empty;
        public int CountedQuantity { get; set; }

        public int InventoryLocationId { get; set; }
        public InventoryLocationDTO Location { get; set; }
    }
}