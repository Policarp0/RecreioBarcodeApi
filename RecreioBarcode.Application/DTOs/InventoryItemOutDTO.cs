namespace RecreioBarcode.Application.DTOs
{
    public sealed class InventoryItemOutDTO
    {
        public int Id { get; private set; }
        public string ItemCode { get; private set; } = string.Empty;
        public int CountedQuantity { get; private set; }

        public int InventoryId { get; set; }
        public Inventory Inventory { get; set; }
        public int LocationFoundId { get; set; }
        public LocationDTO LocationFound { get; set; }
        public int UserId { get; set; }
        public UserDTO User { get; set; }

    }
}
