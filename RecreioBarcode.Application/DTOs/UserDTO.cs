namespace RecreioBarcode.Application.DTOs
{
    public sealed class UserDTO
    {
        public int Id { get; set; } 
        public string Name { get; set; } = string.Empty;

        public ICollection<InventoryItemOutDTO>? InventoryItemsOut { get; set; }
        public ICollection<InventoryLocationDTO>? InventoryLocations { get; set; }
    }
}
