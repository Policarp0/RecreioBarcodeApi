using Microsoft.AspNetCore.Mvc;
using RecreioBarcode.Application.DTOs;
using RecreioBarcode.Application.Interfaces;
using System.ComponentModel;

namespace RecreioBarcode.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class InventoriesController(IInventoryService inventoryService) : Controller
{
    private readonly IInventoryService _inventoryService = inventoryService;

    [HttpGet]
    public async Task<IActionResult> GetInventoriesByStatus(bool isActive)
    {
        var inventories = await _inventoryService.GetAllAsync(x => x.IsActive == isActive); 
        return Ok(inventories);
    }

    //[HttpPost]
    //public async Task<IActionResult> CreateFromCsv(InventoryDTO dto, IFormFile file)
    //{
    //    var newInventory = await _inventoryService.CreateFromCsv(dto);

    //    return Ok(newInventory);
    //}
    [HttpPut]
    public async Task<IActionResult> Put(int id, [FromBody]InventoryDTO dto)
    {
        if(id != dto.Id)
            return BadRequest();
        if (dto is null)
            return BadRequest();

        await _inventoryService.UpdateAsync(dto);
            return Ok(dto);
    }

    [HttpDelete("{id}:int")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _inventoryService.GetAsync(x => x.Id == id);
        if (result is null)
        {
            return NotFound("Not found");
        }
        else
        {
            await _inventoryService.DeleteAsync(result);
            return Ok(result);
        }      
    }
}
