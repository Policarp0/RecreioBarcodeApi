using Microsoft.AspNetCore.Mvc;

namespace RecreioBarcodeApi.Controllers
{
    public class InventoryLineController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetInventoryLineByLocationId()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateInventoryLine()
        {
            return View();
        }
    }
}
