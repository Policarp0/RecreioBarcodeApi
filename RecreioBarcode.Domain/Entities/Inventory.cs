
using RecreioBarcode.Domain.Exceptions;

namespace RecreioBarcode.Domain.Entities;

public sealed class Inventory
{
    public int Id { get; private set; }
    public string Name { get; private set; } = string.Empty;
    public DateTime CreatedAt { get; private set; }
    public DateTime? FinishedAt { get; private set; } = null;
    public bool IsActive { get; private set; }
    public bool IsOpen { get; private set; } 

    private readonly List<InventoryItemOut> _itemsOut = [];
    public IReadOnlyCollection<InventoryItemOut> InventoryItemsOut => _itemsOut.AsReadOnly();    // Um inventário pode ter múltiplos itens fora do inventário.
    
    private readonly List<InventoryLocation> _locations = [];
    public IReadOnlyCollection<InventoryLocation> InventoryLocations => _locations.AsReadOnly(); // Um inventário pode ter múltiplas locações de inventário.

    private Inventory(){ }
    public Inventory(string name)
    {
        ValidateName(name);
        CreatedAt = DateTime.UtcNow;
        Name = name;
        IsActive = true;
        IsOpen = false;
    }

    public void ChangeName(string name)
    {
        ValidateName(name);
        Name = name;
    }
    public void Start()
    {
        if (!IsActive)
            throw new DomainException("Inventory is inactive");
        if (IsOpen)
            throw new DomainException("Inventory has already started");

        IsOpen = true;
    }
    public void Finish()
    {
        if (!IsActive || !IsOpen)
            throw new DomainException("Inventory is already finished");
        CanAlter();

        Close();    
        IsActive = false; 
        FinishedAt = DateTime.UtcNow;
    }

    private void ValidateName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new DomainException("Name is required");
        if (name.Length > 30)
            throw new DomainException("Name is too long");
    }
    private void Close()
    {
        if (!IsActive)
            throw new DomainException("Inventory is inactive");
        IsOpen = false;
    }
    private void CanAlter()
    {
        if (!IsActive)
            throw new DomainException("Inventory is inactive");
        if (!IsOpen)
            throw new DomainException("Inventory is not open");
    }

    public void AddItemOut(string code, decimal count, InventoryLocation foundLocation)
    {
        CanAlter();

        if (foundLocation is null)
            throw new DomainException("Location is required.");

        var inventoryLocation = _locations.FirstOrDefault(x => x.Id == foundLocation.Id)
            ?? throw new DomainException("Location does not belong to this inventory");

        if (inventoryLocation.IsInventoried)
            throw new DomainException("Location already inventoried");

        var itemOut = new InventoryItemOut(code, count, inventoryLocation, this);

        _itemsOut.Add(itemOut);
    }
    public void UpdateItemOut(int id, InventoryLocation foundLocation, string code, decimal count)
    {
        CanAlter();

        var item = InventoryItemsOut.FirstOrDefault(i => i.Id == id)
            ?? throw new DomainException("Item not found");

        var inventoryLocation = _locations.FirstOrDefault(x => x.Id == foundLocation.Id)
            ?? throw new DomainException("Location does not belong to this inventory");
        
        if (inventoryLocation.IsInventoried)
            throw new DomainException("Location already inventoried");

        item.Update(inventoryLocation, code, count);
    }
    public void RemoveItemOut(int itemId)
    {
        CanAlter();

        var item = _itemsOut.FirstOrDefault(i => i.Id == itemId)
            ?? throw new DomainException("Item not found");

        _itemsOut.Remove(item);
    }

    public void AddLocation(Location location)
    {
        CanAlter();

        if (_locations.FirstOrDefault(x => x.LocationId == location.Id) is not null)
            throw new DomainException("Location already exists.");

        var inventoryLocation = new InventoryLocation(location, this);

        _locations.Add(inventoryLocation);
    }
    public void MarkInventoryLocationAsInventoried(int id)
    {
        CanAlter();

        var inventoryLocation = _locations.FirstOrDefault(i => i.Id == id);
        if ((inventoryLocation is null))
            throw new DomainException("Location not found.");
        
        inventoryLocation.MarkAsInventoried();

    }
}
