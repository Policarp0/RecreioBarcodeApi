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
        var inventories = await _inventoryService.GetAllWhereAsync(x => x.IsActive == isActive); 
        return Ok(inventories);
    }

    [HttpPatch("{id:int}")]
    public async Task<IActionResult> Patch(int id, [FromBody] UpdateInventoryDTO dto)
    {
        var sucess = await _inventoryService.UpdateAsync(id, dto);

        if (sucess)
            return Ok("Inventário atualizado");
        else
            return BadRequest("Erro ao atualizar inventário.");     
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var sucess = await _inventoryService.DeleteAsync(id);
        if (sucess)
            return Ok("Inventário excluído.");
        else
            return BadRequest("Erro ao excluir inventário."); 
    }
}
