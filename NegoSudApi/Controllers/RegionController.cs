using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NegoSudApi.Models;
using NegoSudApi.Services.Interfaces;

namespace NegoSudApi.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class RegionController : ControllerBase
{
    private readonly IRegionService _regionService;

    public RegionController(IRegionService regionService)
    {
        _regionService = regionService;
    }

    /// <summary>
    /// Method to return a region matching query
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public async Task<IActionResult> GetRegionAsync(int id)
    {
        Region? dbRegion = await _regionService.GetRegionAsync(id);

        if (dbRegion == null)
        {
            return StatusCode(StatusCodes.Status204NoContent, $"No regions found for id: {id}");
        }

        return StatusCode(StatusCodes.Status200OK, dbRegion);
    }

    /// <summary>
    /// Method to return all existing regions
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public async Task<IActionResult> GetRegionsAsync()
    {
        IEnumerable<Region>? dbRegions = await _regionService.GetRegionsAsync();

        if (dbRegions == null)
        {
            return StatusCode(StatusCodes.Status204NoContent, "No regions in database");
        }

        return StatusCode(StatusCodes.Status200OK, dbRegions);
    }

    /// <summary>
    /// Method to add a new region to the database
    /// </summary>
    /// <param name="region"></param>
    /// <returns></returns>
    [HttpPost("AddRegion")]
    public async Task<ActionResult<Region>> AddRegionAsync(Region region)
    {
        Region? dbRegion = await _regionService.AddRegionAsync(region);

        if (dbRegion == null)
        {
            return StatusCode(StatusCodes.Status204NoContent, $"{region.Name} could not be added.");
        }

        return StatusCode(StatusCodes.Status201Created, dbRegion);
    }

    /// <summary>
    /// Update existing record matching query
    /// </summary>
    /// <param name="id"></param>
    /// <param name="region"></param>
    /// <returns></returns>
    [HttpPost("UpdateRegion")]
    public async Task<IActionResult> UpdateRegionAsync(Region region)
    {
        if (region == null)
        {
            return BadRequest();
        }

        Region? dbRegion = await _regionService.UpdateRegionAsync(region);

        if (dbRegion == null)
        {
            return StatusCode(StatusCodes.Status204NoContent, $"No Region found for id: {region.Id} - could not update.");
        }

        return StatusCode(StatusCodes.Status200OK, dbRegion);
    }
    
    /// <summary>
    /// Delete individual region matching query 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpPost("DeleteRegion")]
    public async Task<IActionResult> DeleteRegionAsync(int id)
    {
        Region? dbRegion = await _regionService.GetRegionAsync(id);

        if (dbRegion == null)
        {
            return StatusCode(StatusCodes.Status204NoContent, $"No Region found for id: {id} - could not be deleted");
        }

        await _regionService.DeleteRegionAsync(id);

        return StatusCode(StatusCodes.Status200OK, $"Region deleted with success");
    }

}


