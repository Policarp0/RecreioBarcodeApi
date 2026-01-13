using Microsoft.AspNetCore.Mvc;
using RecreioBarcode.Application.Interfaces;

namespace RecreioBarcode.WebUI.Controllers;

public class InventoryController(IInventoryService inventoryService) : Controller
{
    private readonly IInventoryService _inventoryService = inventoryService;
    public async Task<IActionResult> Index()
    {
        var Inventories = await _inventoryService.GetAllAsync();
        return View(Inventories);
    }

}
