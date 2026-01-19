
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

    private readonly List<InventoryItemOut> _inventoryItemsOut = [];
    public IReadOnlyCollection<InventoryItemOut> InventoryItemsOut => _inventoryItemsOut.AsReadOnly();    // Um inventário pode ter múltiplos itens fora do inventário.
    
    private readonly List<InventoryLocation> _inventoryLocations = [];
    public IReadOnlyCollection<InventoryLocation> InventoryLocations => _inventoryLocations.AsReadOnly(); // Um inventário pode ter múltiplas locações de inventário.

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
        if (IsOpen)
            throw new DomainException("Inventory already open");
    }

    public void AddItemOut(string code, decimal count, InventoryLocation foundLocation)
    {
        CanAlter();

        if (foundLocation is null)
            throw new DomainException("Location is required.");

        var inventoryLocation = _inventoryLocations.FirstOrDefault(x => x.Id == foundLocation.Id)
            ?? throw new DomainException("Location does not belong to this inventory");

        if (inventoryLocation.IsInventoried)
            throw new DomainException("Location already inventoried");

        var itemOut = new InventoryItemOut(code, count, inventoryLocation, this);

        _inventoryItemsOut.Add(itemOut);
    }
    public void UpdateItemOut(int id, InventoryLocation foundLocation, string code, decimal count)
    {
        CanAlter();

        var item = InventoryItemsOut.FirstOrDefault(i => i.Id == id)
            ?? throw new DomainException("Item not found");

        var inventoryLocation = _inventoryLocations.FirstOrDefault(x => x.Id == foundLocation.Id)
            ?? throw new DomainException("Location does not belong to this inventory");
        
        if (inventoryLocation.IsInventoried)
            throw new DomainException("Location already inventoried");

        item.Update(inventoryLocation, code, count);
    }
    public void RemoveItemOut(int itemId)
    {
        CanAlter();

        var item = _inventoryItemsOut.FirstOrDefault(i => i.Id == itemId)
            ?? throw new DomainException("Item not found");

        _inventoryItemsOut.Remove(item);
    }

    // Função idempotente, chamar ela mais de uma vez nao altera o resultado
    public InventoryLocation GetOrAddInventoryLocation(Location location)
    {
        CanAlter();

        if (location is null)
            throw new DomainException("Location is required.");

        var existing = _inventoryLocations.FirstOrDefault(x => x.LocationId == location.Id);
        if (existing is not null)
            return existing;

        var created = new InventoryLocation(location, this);
        _inventoryLocations.Add(created);

        return created;
    }

    public InventoryLine GetOrAddInventoryLine(string itemCode, Location location)
    {
        CanAlter();

        if (string.IsNullOrWhiteSpace(itemCode))
            throw new DomainException("Item code is required.");
        if (location is null)
            throw new DomainException("Location is required.");

        var inventoryLocation = _inventoryLocations.FirstOrDefault(il =>il.LocationId == location.Id)
            ?? throw new DomainException("Location doesn't exists in this inventory");
        
        var existing = inventoryLocation.InventoryLines.FirstOrDefault(il => il.ItemCode == itemCode);
        if (existing is not null) 
            return existing;

        return inventoryLocation.GetOrAddInventoryLine(itemCode);
    }
    public void MarkInventoryLocationAsInventoried(int id)
    {
        CanAlter();

        var inventoryLocation = _inventoryLocations.FirstOrDefault(i => i.Id == id);
        if ((inventoryLocation is null))
            throw new DomainException("Location not found.");
        
        inventoryLocation.MarkAsInventoried();

    }
}
