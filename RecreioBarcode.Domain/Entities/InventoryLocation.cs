using RecreioBarcode.Domain.Exceptions;
using System.Net.Http.Headers;

namespace RecreioBarcode.Domain.Entities;

public sealed class InventoryLocation
{
    public int Id { get; private set; }
    public bool IsInventoried { get; private set; } = false;
    public DateTime? InventoriedAt { get; private set; } = null;

    public int InventoryId { get; private set; }                                     // Foreign key para Inventory.
    public int LocationId { get; private set; }                                      // Foreign key para Location.
    
    public Inventory Inventory { get; private set; } = null!;                        // Uma locação de inventário pertence a um inventário.
    public Location Location { get; private set; } = null!;                          // Uma locação de inventário pertence a uma locação.

    private readonly List<InventoryLine> _inventoryLines = [];
    public IReadOnlyCollection<InventoryLine> InventoryLines => _inventoryLines.AsReadOnly();  // Uma locação de inventário pode ter múltiplas linhas de inventário.

    private InventoryLocation(){}
    internal InventoryLocation(Location location, Inventory inventory)
    {
        if (inventory is null)
            throw new DomainException("Inventory is required.");
        if (location is null)
            throw new DomainException("Location is required.");

        InventoryId = inventory.Id;
        Inventory = inventory;
        LocationId = location.Id;
        Location = location;
    }

    public void MarkAsInventoried()
    {
        if (IsInventoried)
            throw new DomainException("Location already inventoried.");

        IsInventoried = true;
        InventoriedAt = DateTime.UtcNow;
    }

    public void AddLine(string itemCode)
    {
        if(IsInventoried)
            throw new DomainException("Location already inventoried.");

        if (_inventoryLines.Any(x => x.ItemCode == itemCode))
            throw new DomainException("Item code already added.");

        var newLine = new InventoryLine(itemCode, this);
        _inventoryLines.Add(newLine);
    }
}