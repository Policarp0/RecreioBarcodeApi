using Microsoft.AspNetCore.Mvc;
using RecreioBarcode.Application.UseCase.Inventories.CreateInventory;
using RecreioBarcode.Application.UseCase.Inventories.CreateInventoryFromCsv;
using RecreioBarcode.WebUI.ViewModel;

namespace RecreioBarcode.WebUI.Controllers;

public class InventoryController(ICreateInventoryFromCsv createFromCsv) : Controller
{
    private readonly ICreateInventoryFromCsv _createFromCsv = createFromCsv;

    [HttpGet]
    public IActionResult CreateFromCsv()
        => View(new CreateInventoryFromCsvViewModel());

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> CreateFromCsv(CreateInventoryFromCsvViewModel vm, CancellationToken ct)
    {
        if (string.IsNullOrWhiteSpace(vm.Name))
            ModelState.AddModelError(nameof(vm.Name), "Name is required.");

        if (vm.File is null || vm.File.Length == 0)
            ModelState.AddModelError(nameof(vm.File), "CSV file is required.");

        if (!ModelState.IsValid)
            return View(vm);

        await using var stream = vm.File!.OpenReadStream();

        var cmd = new CreateInventoryFromCsvCommand(vm.Name, stream);
        var result = await _createFromCsv.Handle(cmd, ct);

        return RedirectToAction(nameof(Details), new { id = result.Id });
    }

    public IActionResult Details(int id)
    {
        // aqui você chama outro use case de query
        return View();
    }
}
