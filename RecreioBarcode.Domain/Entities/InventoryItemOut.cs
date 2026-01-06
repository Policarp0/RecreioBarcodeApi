namespace RecreioBarcode.Domain.Entities
{
    public sealed class InventoryItemOut
    {
        public int Id { get; private set; }
        public string ItemCode { get; private set; } = string.Empty;
        public int Count { get; private set; } = 1;

        public int InventoryId { get; set; }        // Foreign key para Inventory.
        public Inventory? Inventory { get; set; }    // Um item fora do inventário pertence a um inventário.
        public int LocationId { get; set; }         // Foreign key para Location.
        public Location? Location { get; set; }      // Um item fora do inventário é encontrado em uma locação.
        public int UserId { get; set; }             // Foreign key para User.
        public User? User { get; set; }              // Um item fora do inventário é registrado por um usuário.

        public InventoryItemOut(string itemCode, int count)
        {
            Validate(itemCode, count);
            
        }
        public InventoryItemOut(int id, string itemCode, int count)
        {
            Id = id;
            Validate(itemCode, count);
            
        }
        public void Validate(string itemCode, int count)
        {
            ItemCode = itemCode;
            Count = count;
        }
        public void Update(string itemCode, int count, int inventoryId, int locationId, int userId)
        {
            InventoryId = inventoryId;
            LocationId = locationId;
            UserId= userId;
            Validate(itemCode, count);

        }
    }
}
