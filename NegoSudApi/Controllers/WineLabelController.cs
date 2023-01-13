using Microsoft.AspNetCore.Mvc;
using NegoSudApi.Models;
using NegoSudApi.Services.Interfaces;

namespace NegoSudApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class WineLabelController : ControllerBase
{
    private readonly IWineLabelService _wineLabelService;

    public WineLabelController(IWineLabelService wineLabelService)
    {
        _wineLabelService = wineLabelService;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetBottleAsync(int id)
    {
        WineLabel? dbWineLabel = await _wineLabelService.GetWineLabelAsync(id);

        if (dbWineLabel == null)
        {
            return StatusCode(StatusCodes.Status204NoContent, $"No WineLabel found for id: {id}");
        }

        return StatusCode(StatusCodes.Status200OK, dbWineLabel);
    }

    [HttpGet]
    public async Task<IActionResult> GetBottlesAsync()
    {
        var dbWineLabels = await _wineLabelService.GetWineLabelsAsync();

        if (dbWineLabels == null)
        {
            return StatusCode(StatusCodes.Status204NoContent, "No wineLabels" +
                " in database");
        }

        return StatusCode(StatusCodes.Status200OK, dbWineLabels);
    }

    [HttpPost]
    public async Task<ActionResult<WineLabel>> AddBottle(WineLabel wineLabel)
    {
        WineLabel? dbWineLabel = await _wineLabelService.AddWineLabelAsync(wineLabel);

        if (dbWineLabel == null)
        {
            return StatusCode(StatusCodes.Status204NoContent, $"{wineLabel.Label} could not be added.");
        }

        return StatusCode(StatusCodes.Status201Created, dbWineLabel);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateBottleAsync(int id, WineLabel wineLabel)
    {
        if (id != wineLabel.Id)
        {
            return BadRequest();
        }

        WineLabel? dbWineLabel = await _wineLabelService.UpdateWineLabelAsync(wineLabel);

        if (dbWineLabel == null)
        {
            return StatusCode(StatusCodes.Status204NoContent, $"No match for query - could not update");
        }

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteBottleAsync(int id)
    {
        bool? status = await _wineLabelService.DeleteWineLabelAsync(id);

        if (status == false)
        {
            return StatusCode(StatusCodes.Status204NoContent, $"No WineLabel found for id: {id} - could not be deleted");
        }

        return StatusCode(StatusCodes.Status200OK);
    }
}

