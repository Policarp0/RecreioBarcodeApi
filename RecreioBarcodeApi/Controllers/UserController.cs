using Microsoft.AspNetCore.Mvc;

namespace RecreioBarcode.Api.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> GetConnectedUsers()
        {
            return View();
        }
    }
}
