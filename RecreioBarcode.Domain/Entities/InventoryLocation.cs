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

        public InventoryLocation(bool isInventoried, DateTime inventoriedAt)
        {
            Validate(isInventoried, inventoriedAt);
        }
        public InventoryLocation(int id, bool isInventoried, DateTime inventoriedAt)
        {
            Id=id;
            Validate(isInventoried, inventoriedAt);
        }

        private void Validate(bool isInventoried, DateTime inventoriedAt)
        {
            IsInventoried = isInventoried;
            InventoriedAt = inventoriedAt;
        }
        public void Update(bool isInventoried, DateTime inventoriedAt, int inventoryId, int locationId, int userId)
        {
            InventoryId = inventoryId;
            LocationId = locationId;
            UserId = userId;
            Validate(isInventoried, inventoriedAt);
        }
    }
}