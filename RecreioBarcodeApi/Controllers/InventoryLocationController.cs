using Microsoft.AspNetCore.Mvc;

namespace RecreioBarcodeApi.Controllers
{
    public class InventoryLocationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetInventoryCategories()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetInventoryCategoriesByLocation(
            char zonaInitial, char zonaFinal,
            int ruaInicial, int ruaFinal,
            int estanteInitial, int estanteFinal,
            char prateleiraInitial, char prateleiraFinal,
            int numeroInitial, int numeroFinal)
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateInventoryLocation()
        {
            return View();
        }
    }

}
