namespace RecreioBarcode.Application.DTOs
{ 
    public sealed class LocationDTO
    {
        public int Id { get; private set; }
        public char Zona { get; private set; }
        public int Rua { get; private set; }
        public int Estante { get; private set; }
        public char Prateleira { get; private set; }
        public int numero { get; private set; }

        public ICollection<InventoryLocationDTO> InventoryLocations{ get; set; }
        public ICollection<InventoryItemOutDTO> InventoryItemsOut{ get; set; }

        public override string ToString()
        {
            return $"{Zona}{Rua}-{Estante}-{Prateleira}{numero}";
        }
    }
}
