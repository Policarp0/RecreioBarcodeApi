namespace RecreioBarcode.Domain.Entities
{
    public sealed class User
    {
        public int Id { get; private set; } 
        public string Name { get; private set; } = string.Empty;

        public ICollection<InventoryItemOut>? InventoryItemsOut { get; set; }   // Um usuário pode registrar múltiplos itens fora do inventário.
        public ICollection<InventoryLocation>? InventoryLocations { get; set; } // Um usuário pode contar múltiplas locações de inventário.
    }
}
