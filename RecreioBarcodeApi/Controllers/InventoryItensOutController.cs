using Microsoft.AspNetCore.Mvc;

namespace RecreioBarcode.Api.Controllers
{
    public class InventoryItensOutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create()
        {
            return View();
        }
    }
}
