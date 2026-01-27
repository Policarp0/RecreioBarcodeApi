using Microsoft.AspNetCore.Mvc;
using RecreioBarcode.Application.UseCase.Inventories.Commands.Create;
using RecreioBarcode.WebUI.ViewModel;
using RecreioBarcode.WebUI.ViewModels;

namespace RecreioBarcode.WebUI.Controllers;

public class InventoryController : Controller
{

    [HttpGet]
    public IActionResult Dashboard()
    {
        return View(); 
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View(new CreateInventoryFromCsvViewModel());
    }
    [HttpGet]
    public IActionResult Edit()
    {
        return View(new CreateInventoryFromCsvViewModel());
    }
    [HttpGet]
    public IActionResult Details()
    {
        return View(new CreateInventoryFromCsvViewModel());
    }
    [HttpGet]
    public IActionResult Delete()
    {
        return View(new CreateInventoryFromCsvViewModel());
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(CreateInventoryFromCsvViewModel vm, CancellationToken ct)
    {
        if (string.IsNullOrWhiteSpace(vm.Name))
            ModelState.AddModelError(nameof(vm.Name), "Name is required.");

        if (vm.File is null || vm.File.Length == 0)
            ModelState.AddModelError(nameof(vm.File), "CSV file is required.");

        if (!ModelState.IsValid)
            return View(vm);

        await using var stream = vm.File!.OpenReadStream();

        var cmd = new CreateCommand(vm.Name, stream);

        return RedirectToAction("Index");
    }
}
