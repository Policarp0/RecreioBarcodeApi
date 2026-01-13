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
        var inventories = await _inventoryService.GetAllAsync(x => x.IsActive == isActive); 
        return Ok(inventories);
    }

    [HttpPost("import")]
    public async Task<IActionResult> CreateFromCsv([FromForm] IFormFile file)
    {
        if (file == null || file.Length == 0)
            return BadRequest("Nenhum arquivo enviado.");

        var allowedExtensions = new[] { ".csv", ".txt" };
        var extension = Path.GetExtension(file.FileName)?.ToLowerInvariant();
        if (string.IsNullOrWhiteSpace(extension) || !allowedExtensions.Contains(extension))
            return BadRequest("Tipo de arquivo inválido.");

        await using var stream = file.OpenReadStream();
        var result = await _inventoryService.CreateFromCsvAsync(stream);

        return Ok();
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
