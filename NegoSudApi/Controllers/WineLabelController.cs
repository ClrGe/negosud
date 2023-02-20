using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NegoSudApi.Models;
using NegoSudApi.Services.Interfaces;

namespace NegoSudApi.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class WineLabelController : ControllerBase
{
    private readonly IWineLabelService _wineLabelService;

    public WineLabelController(IWineLabelService wineLabelService)
    {
        _wineLabelService = wineLabelService;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetWineLabelAsync(int id)
    {
        WineLabel? dbWineLabel = await _wineLabelService.GetWineLabelAsync(id);

        if (dbWineLabel == null)
        {
            return StatusCode(StatusCodes.Status204NoContent, $"No WineLabel found for id: {id}");
        }

        return StatusCode(StatusCodes.Status200OK, dbWineLabel);
    }

    [HttpGet]
    public async Task<IActionResult> GetWineLabelsAsync()
    {
        var dbWineLabels = await _wineLabelService.GetWineLabelsAsync();

        if (dbWineLabels == null)
        {
            return StatusCode(StatusCodes.Status204NoContent, "No wineLabels in database");
        }

        return StatusCode(StatusCodes.Status200OK, dbWineLabels);
    }

    [HttpPost("WineLabel")]
    public async Task<ActionResult<WineLabel>> AddWineLabelAsync(WineLabel wineLabel)
    {
        WineLabel? dbWineLabel = await _wineLabelService.AddWineLabelAsync(wineLabel);

        if (dbWineLabel == null)
        {
            return StatusCode(StatusCodes.Status204NoContent, $"{wineLabel.Label} could not be added.");
        }

        return StatusCode(StatusCodes.Status201Created, dbWineLabel);
    }

    [HttpPost("UpdateWineLabel")]
    public async Task<IActionResult> UpdateWineLabelAsync(WineLabel wineLabel)
    {
        if (wineLabel == null)
        {
            return BadRequest();
        }

        WineLabel? dbWineLabel = await _wineLabelService.UpdateWineLabelAsync(wineLabel);

        if (dbWineLabel == null)
        {
            return StatusCode(StatusCodes.Status204NoContent, $"No WineLabel found for id: {wineLabel.Id} - could not update.");
        }

        return StatusCode(StatusCodes.Status200OK, dbWineLabel);
    }

    [HttpPost("DeleteWineLabel")]
    public async Task<IActionResult> DeleteWineLabelAsync(int id)
    {
        bool? status = await _wineLabelService.DeleteWineLabelAsync(id);

        if (status == false)
        {
            return StatusCode(StatusCodes.Status204NoContent, $"No WineLabel found for id: {id} - could not be deleted");
        }

        return StatusCode(StatusCodes.Status200OK);
    }
}

