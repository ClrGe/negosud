using Microsoft.AspNetCore.Mvc;
using NegoSudApi.Models;
using NegoSudApi.Services.Interfaces;

namespace NegoSudApi.Controllers;


[ApiController]
[Route("api/[controller]")]

public class RegionController : ControllerBase
{
    private readonly IRegionService _RegionService;

    public RegionController(IRegionService regionService)
    {
        _RegionService = regionService;
    }

    // method to return a region matching query
    [HttpGet("{id}")]
    public async Task<IActionResult> GetRegionAsync(int id)
    {
        Region? region = await _RegionService.GetRegionAsync(id);

        if (region == null)
        {
            return StatusCode(StatusCodes.Status204NoContent, $"No match for query");
        }

        return StatusCode(StatusCodes.Status200OK, region);
    }

    // method to return all existing regions
    [HttpGet]
    public async Task<IActionResult> GetRegionsAsync()
    {
        IEnumerable<Region>? regions = await _RegionService.GetRegionsAsync();

        if (regions == null)
        {
            return StatusCode(StatusCodes.Status204NoContent, $"No match for query");
        }

        return StatusCode(StatusCodes.Status200OK, regions);
    }

    // method to add a new region to the database
    [HttpPost]
    public async Task<ActionResult<Region>> AddRegionAsync(Region Region)
    {
        Region? region = await _RegionService.AddRegionAsync(Region);

        if (region == null)
        {
            return StatusCode(StatusCodes.Status204NoContent, $"No match for query");
        }

        return StatusCode(StatusCodes.Status200OK, region);
    }

    // update existing record matching query
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateRegionAsync(int id, Region Region)
    {
        if (id != Region.Id)
        {
            return BadRequest();
        }

        Region? region = await _RegionService.UpdateRegionAsync(Region);

        if (region == null)
        {
            return StatusCode(StatusCodes.Status204NoContent, $"No match for query");
        }

        return StatusCode(StatusCodes.Status200OK, region);
    }

    // delete individual region matching query 
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteRegionAsync(int id)
    {
        Region? region = await _RegionService.GetRegionAsync(id);

        if (region == null)
        {
            return StatusCode(StatusCodes.Status204NoContent, $"No match for query");
        }

        await _RegionService.DeleteRegionAsync(id);

        return StatusCode(StatusCodes.Status200OK, $"Region deleted with success");
    }

}


