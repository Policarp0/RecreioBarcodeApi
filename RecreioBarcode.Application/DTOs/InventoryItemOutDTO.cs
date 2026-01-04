namespace RecreioBarcode.Application.DTOs
{
    public sealed class InventoryItemOutDTO
    {
        public int Id { get; set; }
        public string ItemCode { get; set; } = string.Empty;
        public int CountedQuantity { get; set; }

        public int InventoryId { get; set; }
        public InventoryDTO Inventory { get; set; }
        public int LocationFoundId { get; set; }
        public LocationDTO LocationFound { get; set; }
        public int UserId { get; set; }
        public UserDTO User { get; set; }

    }
}
