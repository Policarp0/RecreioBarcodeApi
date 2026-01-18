
using RecreioBarcode.Domain.Exceptions;

namespace RecreioBarcode.Domain.Entities;

public sealed class InventoryItemOut
{
    public int Id { get; private set; }
    public string ItemCode { get; private set; } = null!;
    public decimal Count { get; private set; } = 1;

    //Navegações DDD
    public Inventory Inventory { get; private set; } = null!;               // Um item fora do inventário pertence a um inventário.
    public InventoryLocation FoundLocation { get; private set; } = null!;   // Um item fora do inventário é encontrado em uma locação.
    
    //Chave Estrangeira Explícita
    public int InventoryId { get; private set; }                            // Foreign key para Inventory.
    public int FoundLocationId { get; private set; }                        // Foreign key para Location.

    private InventoryItemOut() { }
    internal InventoryItemOut(string code, decimal count, InventoryLocation foundLocation, Inventory inventory) : this()
    {
        ValidateCode(code);
        ValidateCount(count);

        Inventory = inventory ?? throw new DomainException("Inventory is required");
        FoundLocation = foundLocation ?? throw new DomainException("Location is required");

        InventoryId = inventory.Id;
        FoundLocationId = foundLocation.Id;

        ItemCode = code.ToUpper();
        Count = count;
    }
    public void Update(InventoryLocation foundLocation,string code, decimal count)
    {
        ValidateCode(code);
        ValidateCount(count);
        if (foundLocation is null)
            throw new DomainException("Location is required");

        ItemCode = code;
        Count = count;
        FoundLocation = foundLocation;
        FoundLocationId = foundLocation.Id;
    }

    private void ValidateCode(string code)
    {
        if (string.IsNullOrWhiteSpace(code))
            throw new DomainException("Code is required");
        if (code.Length > 14)
            throw new DomainException("Code must have max of 14 characters");
    }
    private void ValidateCount(decimal count)
    {
        if (count < 0)
            throw new DomainException("Count must be a positive value");
    } 
}
