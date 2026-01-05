using Microsoft.AspNetCore.Mvc;

namespace RecreioBarcode.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryController : Controller
    {

        [HttpPost]
        public IActionResult Index()
        {
            return View();
        }

    }
}
