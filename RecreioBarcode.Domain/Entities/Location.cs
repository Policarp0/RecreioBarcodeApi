using System.ComponentModel;

namespace RecreioBarcode.Domain.Entities
{
    public sealed class Location
    {
        public int Id { get; private set; }
        public char Zona { get; private set; }
        public int Rua { get; private set; }
        public int Estante { get; private set; }
        public char Prateleira { get; private set; }
        public int Numero { get; private set; }

        public ICollection<InventoryLocation>? InventoryLocations{ get; set;}   // Uma locação pode estar em múltiplas Locações de inventário.
        public ICollection<InventoryItemOut>? InventoryItemsOut{ get; set; }     // Uma locação pode estar em múltiplos Itens fora do inventário.     

        public Location(char zona, int rua, int estante, char prateleira, int numero)
        {
            Validate(zona, rua, estante, prateleira, numero);
        }
        public Location(int id, char zona, int rua, int estante, char prateleira, int numero)
        {
            Id = id;
            Validate(zona, rua, estante, prateleira, numero);
        }

        public void Validate(char zona, int rua, int estante, char prateleira, int numero)
        {
            Zona = zona;    
            Rua = rua;
            Estante = estante;
            Prateleira = prateleira;
            Numero = numero;
        }
        public void Update(char zona, int rua, int estante, char prateleira, int numero)
        {
            Validate(zona, rua, estante, prateleira, numero);
        }

        public override string ToString()
        {
            return $"{Zona}{Rua}-{Estante}-{Prateleira}{Numero}";
        }
    }
}
