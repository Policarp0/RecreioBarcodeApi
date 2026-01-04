using Microsoft.AspNetCore.Mvc;

namespace RecreioBarcode.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryController : Controller
    {
        private readonly InventoryService _service;

        public InventoryController(InventoryService invetoryService)
        {
            _service = invetoryService;
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
        public async Task<IActionResult> CreateInventory([FromBody] Inventory inventory)
        {
   
            await _service.CreateInventoryAsync(inventory);
            return Ok(inventory);   
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
