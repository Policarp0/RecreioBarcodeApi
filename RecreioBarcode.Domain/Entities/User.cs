using System.Net.Http.Headers;

namespace RecreioBarcode.Domain.Entities
{
    public sealed class User
    {
        public int Id { get; private set;} 
        public string Name { get; private set; } = string.Empty;
        public string IpAdress { get; private set; } = string.Empty;

        public ICollection<InventoryItemOut>? InventoryItemsOut { get; set; }   // Um usuário pode registrar múltiplos itens fora do inventário.
        public ICollection<InventoryLocation>? InventoryLocations { get; set; } // Um usuário pode contar múltiplas locações de inventário.

        public User(int id, string name)
        {
            Id=id;
            Validate(name);
        }
        public User(string name)
        {
            Validate(name);
        }
        public void Validate(string name)
        {
            Name = name;
        }
        public void Update(string name)
        {
            Validate(name);
        }
    }
}
