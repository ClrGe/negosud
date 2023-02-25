using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NegoSudApi.Data;
using NegoSudApi.Models;
using NegoSudApi.Services.Interfaces;

namespace NegoSudApi.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class GrapeController : ControllerBase
{
    private readonly IGrapeService _grapeService;
    public GrapeController(IGrapeService grapeService)
    {
        _grapeService = grapeService;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetGrapeAsync(int id)
    {
        Grape? dbGrape = await _grapeService.GetGrapeAsync(id);
        if (dbGrape == null)
        {
            return StatusCode(StatusCodes.Status404NotFound, $"No match for query");
        }
        return StatusCode(StatusCodes.Status200OK, dbGrape);
    }

    [HttpGet]
    public async Task<IActionResult> GetGrapesAsync()
    {
        IEnumerable<Grape>? dbGrapes = await _grapeService.GetGrapesAsync();
        if (dbGrapes == null)
        {
            return StatusCode(StatusCodes.Status404NotFound, $"No match for query");
        }
        return StatusCode(StatusCodes.Status200OK, dbGrapes.ToList());
    }

        [Authorize(Policy = RolePermissions.CanAddGrape)]
        [HttpPost("AddGrape")]
        public async Task<IActionResult> AddGrapeAsync(Grape grape)
        {
            Grape? dbGrape = await _grapeService.AddGrapeAsync(grape);
            if (dbGrape == null)
            {
                return StatusCode(StatusCodes.Status204NoContent, $"{grape.GrapeType} could not be added.");
            }
            return StatusCode(StatusCodes.Status201Created, dbGrape);
        }

        [Authorize(Policy = RolePermissions.CanEditGrape)]
        [HttpPost("UpdateGrape")]
        public async Task<IActionResult> UpdateGrapeAsync(Grape grape)
        {
            if (grape == null)
            {
                return BadRequest();
            }

        Grape? dbGrape = await _grapeService.UpdateGrapeAsync(grape);
        if (dbGrape == null)
        {
            return StatusCode(StatusCodes.Status404NotFound, $"No Country found for id: {grape.Id} - could not update.");
        }
        return StatusCode(StatusCodes.Status200OK, dbGrape);
    }

        [Authorize(Policy = RolePermissions.CanDeleteGrape)]
        [HttpPost("DeleteGrape")]
        public async Task<IActionResult> DeleteGrapeAsync(int id)
        {
            Grape? dbGrape = await _grapeService.GetGrapeAsync(id);
            if (dbGrape == null)
            {
                return StatusCode(StatusCodes.Status204NoContent, $"No Grape found for id: {id} - could not be deleted");
            }
            await _grapeService.DeleteGrapeAsync(id);
            return StatusCode(StatusCodes.Status200OK);
        }

}