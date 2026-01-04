using Microsoft.AspNetCore.Mvc;
using RecreioBarcodeApi.Services;

namespace RecreioBarcodeApi.Controllers
{
    public class InventoryController : Controller
    {
        private readonly InventoryService _inventoryService;

        public InventoryController(InventoryService invetoryService)
        {
            _inventoryService = invetoryService;
        }

        [HttpPost]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetActiveInventories()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetInactiveInventories()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateInventory()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateInventory()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> DeleteInventory()
        {
            return View();
        }
    }
}
