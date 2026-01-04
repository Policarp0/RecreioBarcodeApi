namespace RecreioBarcode.Domain.Entities
{
    public sealed class InventoryLocation
    {
        public int Id { get; private set; }
        public bool IsInventoried { get; private set; } = false;
        public DateTime InventoriedAt { get; private set; }

        public int InventoryId { get; set; }     // Foreign key para Inventory.
        public Inventory Inventory { get; set; } // Uma locação de inventário pertence a um inventário.
        public int LocationId { get; set; }      // Foreign key para Location.
        public Location Location { get; set; }   // Uma locação de inventário pertence a uma locação.
        public ICollection<InventoryLine> InventoryLines { get; set; } // Uma locação de inventário pode ter múltiplas linhas de inventário.
        public int UserId { get; set; }          // Foreign key para User.
        public User User { get; set; }           // Uma locação de inventário é feita por um usuário.
    }
}