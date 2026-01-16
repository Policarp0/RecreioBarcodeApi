
using RecreioBarcode.Domain.Exceptions;

namespace RecreioBarcode.Domain.Entities;

public sealed class Inventory
{
    public int Id { get; private set; }
    public string Name { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime? FinishedAt { get; private set; } = null;
    public bool IsActive { get; private set; }
    public bool IsOpen { get; private set; } 

    private readonly List<InventoryItemOut> _itemsOut = [];
    public IReadOnlyCollection<InventoryItemOut> InventoryItemsOut => _itemsOut.AsReadOnly();    // Um inventário pode ter múltiplos itens fora do inventário.
    private readonly List<InventoryLocation> _locations = [];
    public IReadOnlyCollection<InventoryLocation> InventoryLocations => _locations.AsReadOnly(); // Um inventário pode ter múltiplas locações de inventário.

    private Inventory() 
    {
        Name = string.Empty;
        CreatedAt = DateTime.UtcNow;
    }
    public Inventory(string name) : this()
    {
        ValidateName(name);
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
    private void Close()
    {
        if (!IsActive)
            throw new DomainException("Inventory is inactive");
        IsOpen = false;
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
    private void CanAlter()
    {
        if (!IsActive)
            throw new DomainException("Inventory is inactive");
        if (!IsOpen)
            throw new DomainException("Inventory is not open");
    }

    public void AddItemOut(Location location, string code, decimal count)
    {
        CanAlter();

        if (location is null)
            throw new DomainException("Location is required");

        var itemOut = new InventoryItemOut(code, count, location, this);

        _itemsOut.Add(itemOut);
    }
    public void UpdateItemOut(int id, Location location, string code, decimal count)
    {
        CanAlter();

        var item = InventoryItemsOut.FirstOrDefault(i => i.Id == id)
            ?? throw new DomainException("Item not found");

        item.Update(location, code, count);
    }
    public void RemoveItemOut(int itemId)
    {
        CanAlter();

        var item = _itemsOut.FirstOrDefault(i => i.Id == itemId)
            ?? throw new DomainException("Item not found");

        _itemsOut.Remove(item);
    }
}
