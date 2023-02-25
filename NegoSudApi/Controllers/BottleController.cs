using HeimGuard;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NegoSudApi.Data;
using NegoSudApi.Models;
using NegoSudApi.Services.Interfaces;

namespace NegoSudApi.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class BottleController : ControllerBase
{
    private readonly IBottleService _bottleService;

    public BottleController(IBottleService bottleService)
    {
        _bottleService = bottleService;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetBottleAsync(int id)
    {
        var dbBottle = await _bottleService.GetBottleAsync(id);

        if (dbBottle == null) return StatusCode(StatusCodes.Status404NotFound, $"No Bottle found for id: {id}");
        Response.Headers.Add("Access-Control-Allow-Origin", "*");

        return StatusCode(StatusCodes.Status200OK, dbBottle);
    }

    [HttpGet]
    public async Task<IActionResult> GetBottlesAsync()
    {
        var dbBottles = await _bottleService.GetBottlesAsync();

        if (dbBottles == null) return StatusCode(StatusCodes.Status404NotFound, "No bottles in database");
        Response.Headers.Add("Access-Control-Allow-Origin", "*");

        return StatusCode(StatusCodes.Status200OK, dbBottles);
    }

    [Authorize(Policy = RolePermissions.CanAddBottle)]
    [HttpPost("AddBottle")]
    public async Task<ActionResult<Bottle>> AddBottle(Bottle bottle)
    {
        Bottle? dbBottle = await _bottleService.AddBottleAsync(bottle);

    if (dbBottle == null)
        return StatusCode(StatusCodes.Status404NotFound, $"{bottle.FullName} could not be added.");

    return StatusCode(StatusCodes.Status201Created, dbBottle);
    }

    [HttpPost("MassAddBottle")]
    public async Task<IActionResult> MassAddBottleAsync(ICollection<Bottle> bottles)
    {
        if (bottles == null) return BadRequest();

        ICollection<Bottle>? dbBottles = await _bottleService.MassAddBottleAsync(bottles);

        return dbBottles == null ? StatusCode(StatusCodes.Status404NotFound, "No match, no changes were made.") : StatusCode(StatusCodes.Status200OK, dbBottles);
    }

    [Authorize(Policy = RolePermissions.CanEditBottle)]
    [HttpPost("UpdateBottle")]
    public async Task<IActionResult> UpdateBottleAsync(Bottle bottle)
    {
        if (bottle == null) return BadRequest();

    var dbBottle = await _bottleService.UpdateBottleAsync(bottle);

    if (dbBottle == null)
        return StatusCode(StatusCodes.Status404NotFound,
            $"No bottle found for id: {bottle.Id} - could not update.");

    return StatusCode(StatusCodes.Status200OK, dbBottle);
    }

    [HttpPost("MassUpdateBottle")]
    public async Task<IActionResult> MassUpdateBottleAsync(ICollection<Bottle> bottles)
    {
        if (bottles == null) return BadRequest();

        ICollection<Bottle>? dbBottles = await _bottleService.MassUpdateBottleAsync(bottles);

               return dbBottles == null ? StatusCode(StatusCodes.Status404NotFound, "No match, no changes were made.") : StatusCode(StatusCodes.Status200OK, dbBottles);

    }

    [Authorize(Policy = RolePermissions.CanDeleteBottle)]
    [HttpPost("DeleteBottle")]
    public async Task<IActionResult> DeleteBottleAsync(int id)
    {
        bool? status = await _bottleService.DeleteBottleAsync(id);

    if (status == false)
        return StatusCode(StatusCodes.Status404NotFound, $"No bottle found for id: {id} - could not be deleted");

    return StatusCode(StatusCodes.Status200OK);
    }
}