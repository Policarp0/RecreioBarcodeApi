using Microsoft.AspNetCore.Mvc;
using RecreioBarcode.Application.DTOs;
using RecreioBarcode.Application.Interfaces;
using System.ComponentModel;
using System.IO;

namespace RecreioBarcode.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class InventoriesController(IInventoryService inventoryService) : Controller
{
    private readonly IInventoryService _inventoryService = inventoryService;

    [HttpGet]
    public async Task<IActionResult> GetInventoriesByStatus(bool isActive)
    {
        return Ok();
    }

    [HttpPatch("{id:int}")]
    public async Task<IActionResult> Patch(int id, [FromBody] UpdateInventoryDTO dto)
    {

            return Ok("Inventário atualizado");
    
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {

            return Ok("Inventário excluído.");

    }
}
