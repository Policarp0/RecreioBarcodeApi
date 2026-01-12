using Microsoft.AspNetCore.Mvc;
using RecreioBarcode.Application.DTOs;
using RecreioBarcode.Application.Interfaces;
using RecreioBarcode.Domain.Entities;

namespace RecreioBarcode.Api.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class InventoryController : Controller
    {
        private readonly IInventoryService _inventoryService;

        public InventoryController(IInventoryService inventoryService)
        {
            _inventoryService = inventoryService;
        }

        [HttpGet]
        [Route("api/[controller]/Actives")]
        public async Task<IActionResult> GetActives()
        {
            var inventories = await _inventoryService.GetAllActiveAsync(); 
            return Ok(inventories);
        }
        [HttpGet]
        [Route("api/[controller]/Inactives")]
        public async Task<IActionResult> GetInactives()
        {
            var inventories = await _inventoryService.GetAllInactiveAsync(); 
            return Ok(inventories);
        }

        [HttpPost]
        [Route("/CreateFromCsv")]
        public async Task<IActionResult> Index(InventoryDTO dto, IFormFile file)
        {
            var newInventory = await _inventoryService.CreateFromCsv(dto);

            return Ok(newInventory);
        }

    }
}
