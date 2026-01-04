namespace RecreioBarcode.Application.DTOs
{ 
    public sealed class LocationDTO
    {
        public int Id { get; set; }
        public char Zona { get; set; }
        public int Rua { get; set; }
        public int Estante { get; set; }
        public char Prateleira { get; set; }
        public int numero { get; set; }

        public ICollection<InventoryLocationDTO> InventoryLocations{ get; set; }
        public ICollection<InventoryItemOutDTO> InventoryItemsOut{ get; set; }

        public override string ToString()
        {
            return $"{Zona}{Rua}-{Estante}-{Prateleira}{numero}";
        }
    }
}
