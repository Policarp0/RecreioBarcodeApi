namespace RecreioBarcode.Domain.Entities
{
    public sealed class InventoryItemOut
    {
        public int Id { get; private set; }
        public string ItemCode { get; private set; } = string.Empty;
        public int CountedQuantity { get; private set; } = 1;

        public int InventoryId { get; set; }        // Foreign key para Inventory.
        public Inventory Inventory { get; set; }    // Um item fora do inventário pertence a um inventário.
        public int LocationFoundId { get; set; }    // Foreign key para Location.
        public Location LocationFound { get; set; } // Um item fora do inventário é encontrado em uma locação.
        public int UserId { get; set; }             // Foreign key para User.
        public User User { get; set; }              // Um item fora do inventário é registrado por um usuário.

    }
}
