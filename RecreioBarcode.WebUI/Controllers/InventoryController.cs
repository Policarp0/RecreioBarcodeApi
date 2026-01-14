using Microsoft.AspNetCore.Mvc;
using RecreioBarcode.Application.Interfaces;

namespace RecreioBarcode.WebUI.Controllers;

public class InventoryController(IInventoryService inventoryService) : Controller
{
    private readonly IInventoryService _inventoryService = inventoryService;

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var Inventories = await _inventoryService.GetAllAsync();
        return View(Inventories);
    }
    [HttpPost]
    public async Task<IActionResult> CreateFromCsv([FromForm] string name, IFormFile file)
    {
        if (file == null || file.Length == 0)
            return Redirect("/index");

        var allowedExtensions = new[] { ".csv", ".txt" };
        var extension = Path.GetExtension(file.FileName)?.ToLowerInvariant();
        if (string.IsNullOrWhiteSpace(extension) || !allowedExtensions.Contains(extension))
            return BadRequest("Tipo de arquivo inválido.");

        await using var stream = file.OpenReadStream();
        var result = await _inventoryService.CreateFromCsvAsync(name,stream);

        return View();
    }

}
