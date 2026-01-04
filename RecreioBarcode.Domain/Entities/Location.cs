namespace RecreioBarcode.Domain.Entities
{
    public sealed class Location
    {
        public int Id { get; private set; }
        public char Zona { get; private set; }
        public int Rua { get; private set; }
        public int Estante { get; private set; }
        public char Prateleira { get; private set; }
        public int numero { get; private set; }

        public ICollection<InventoryLocation> InventoryLocations{ get; set; }
        public ICollection<InventoryItemOut> InventoryItemsOut{ get; set; }

        public override string ToString()
        {
            return $"{Zona}{Rua}-{Estante}-{Prateleira}{numero}";
        }
    }
}
