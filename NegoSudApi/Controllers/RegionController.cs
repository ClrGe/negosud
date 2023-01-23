using Microsoft.AspNetCore.Mvc;
using NegoSudApi.Models;
using NegoSudApi.Services.Interfaces;

namespace NegoSudApi.Controllers;


[ApiController]
[Route("api/[controller]")]

public class RegionController : ControllerBase
{
    private readonly IRegionService _regionService;

    public RegionController(IRegionService regionService)
    {
        _regionService = regionService;
    }

    // method to return a region matching query
    [HttpGet("{id}")]
    public async Task<IActionResult> GetRegionAsync(int id)
    {
        Region? dbRegion = await _regionService.GetRegionAsync(id);

        if (dbRegion == null)
        {
            return StatusCode(StatusCodes.Status204NoContent, $"No match for query");
        }

        return StatusCode(StatusCodes.Status200OK, dbRegion);
    }

    // method to return all existing regions
    [HttpGet]
    public async Task<IActionResult> GetRegionsAsync()
    {
        IEnumerable<Region>? dbRegions = await _regionService.GetRegionsAsync();

        if (dbRegions == null)
        {
            return StatusCode(StatusCodes.Status204NoContent, $"No match for query");
        }

        return StatusCode(StatusCodes.Status200OK, dbRegions);
    }

    // method to add a new region to the database
    [HttpPost]
    public async Task<ActionResult<Region>> AddRegionAsync(Region region)
    {
        Region? dbRegion = await _regionService.AddRegionAsync(region);

        if (dbRegion == null)
        {
            return StatusCode(StatusCodes.Status204NoContent, $"No match for query");
        }

        return StatusCode(StatusCodes.Status201Created, dbRegion);
    }

    // update existing record matching query
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateRegionAsync(int id, Region region)
    {
        if (id != region.Id)
        {
            return BadRequest();
        }

        Region? dbRegion = await _regionService.UpdateRegionAsync(region);

        if (dbRegion == null)
        {
            return StatusCode(StatusCodes.Status204NoContent, $"No match for query");
        }

        return StatusCode(StatusCodes.Status200OK, dbRegion);
    }

    // delete individual region matching query 
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteRegionAsync(int id)
    {
        Region? dbRegion = await _regionService.GetRegionAsync(id);

        if (dbRegion == null)
        {
            return StatusCode(StatusCodes.Status204NoContent, $"No match for query");
        }

        await _regionService.DeleteRegionAsync(id);

        return StatusCode(StatusCodes.Status200OK, $"Region deleted with success");
    }

}


