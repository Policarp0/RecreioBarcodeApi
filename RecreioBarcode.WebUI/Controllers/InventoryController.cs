using Microsoft.AspNetCore.Mvc;
using RecreioBarcode.Application.Interfaces;
using RecreioBarcode.WebUI.ViewModel;

namespace RecreioBarcode.WebUI.Controllers;

public class InventoryController(IInventoryService inventoryService) : Controller
{
    private readonly IInventoryService _inventoryService = inventoryService;

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        return View();
    }
    [HttpGet]
    public async Task<IActionResult> Management(int id)
    {
        var Inventory = await _inventoryService.GetByIdAsync(id);
        return View(Inventory);
    }

    [HttpGet]
    public async Task<IActionResult> Lines(int id)
    {
        return View();
    }

    [HttpGet]
    public async Task<IActionResult> Locations(int id)
    {
        return View();
    }

    [HttpGet]
    public async Task<IActionResult> ItemsOut(int id)
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> CreateFromCsv([FromForm] string name, IFormFile file)
    {
        if (file == null || file.Length == 0)
            return BadRequest("Tipo de arquivo inválido.");

        var allowedExtensions = new[] { ".csv", ".txt" };
        var extension = Path.GetExtension(file.FileName)?.ToLowerInvariant();
        if (string.IsNullOrWhiteSpace(extension) || !allowedExtensions.Contains(extension))
            return BadRequest("Tipo de arquivo inválido.");

        await using var stream = file.OpenReadStream();
        var result = await _inventoryService.CreateFromCsvAsync(name,stream);

        return RedirectToAction(nameof(Index));
    }
}
