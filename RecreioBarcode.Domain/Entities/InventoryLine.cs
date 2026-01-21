using RecreioBarcode.Domain.Exceptions;

namespace RecreioBarcode.Domain.Entities;

public sealed class InventoryLine
{
    public int Id { get; private set; }
    public string ItemCode { get; private set; } = string.Empty;
    public int Count { get; private set; } = 0;

    public int InventoryLocationId { get; private set; }                      // Foreign key para InventoryLocation.
    public InventoryLocation InventoryLocation { get; private set; } = null!; // Uma linha de inventário pertence a uma locação de inventário.

    private InventoryLine() {}
    internal InventoryLine(string itemCode, InventoryLocation inventoryLocation)
    { 
        if (inventoryLocation is null)
            throw new DomainException("Inventory location is required.");

        Validate(itemCode);

        ItemCode = itemCode;
        InventoryLocation = inventoryLocation;
    }

    private void Validate(string itemCode)
    {
        if (string.IsNullOrWhiteSpace(itemCode))
            throw new DomainException("Item code is required."); 
    }

    public void ChangeCount(int count)
    {
        if (count is < 0)
            throw new DomainException("Count must be a positive value.");
        
        Count = count;  
    }
    public override string ToString()
    {
        return $"{ItemCode} - {Count}";
    }
}