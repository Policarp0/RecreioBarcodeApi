
namespace RecreioBarcode.Domain.Entities
{
    public class Inventory
    {
        public int Id { get; private set; }
        public string Name { get; private set; } = string.Empty;
        public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;
        public DateTime? FinishedAt { get; private set; } = null;
        public bool IsActive { get; private set; } = true;
        public string ChargerFilePath { get; private set; } = string.Empty;

        public ICollection<InventoryItemOut>? InventoryItemsOut { get; set; }  // Um inventário pode ter múltiplos itens fora do inventário.
        public ICollection<InventoryLocation> InventoryLocations { get; set; } // Um inventário pode ter múltiplas locações de inventário.

        public Inventory(int id, string name, DateTime? finishedAt, bool isActive, string chargerFilePath)
        {
            Id = id;
            Validate(name, finishedAt, isActive, chargerFilePath);
        }
        public Inventory(string name, DateTime? finishedAt, bool isActive, string chargerFilePath)
        {
            Validate(name, finishedAt, isActive, chargerFilePath);
        }
       
        public void Validate(string name, DateTime? finishedAt, bool isActive, string chargerFilePath)
        {
            Name = name;
            FinishedAt = finishedAt;
            IsActive = isActive;
            ChargerFilePath = chargerFilePath;
        }
        public void Update(string name, DateTime? finishedAt, bool isActive, string chargerFilePath)
        {
            Validate(name, finishedAt, isActive, chargerFilePath);
        }
    }
}
