using Microsoft.AspNetCore.Mvc;
using NegoSudApi.Models;
using NegoSudApi.Services;

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
        [HttpGet("id")]
        public async Task<IActionResult> GetRegion(int id)
        {
            Region? region = await _RegionService.GetRegion(id);

            if ( region== null)
            {
                return StatusCode(StatusCodes.Status404NotFound, $"404 No match for query");
            }

            return StatusCode(StatusCodes.Status200OK, region);
        }

        // method to return all existing regions
        [HttpGet]
        public async Task<IActionResult> GetRegions()
        {
            var regions = await _RegionService.GetRegions();

            if (regions == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, "Oops, no match");
            }

            return StatusCode(StatusCodes.Status200OK, regions);
        }

        // method to add a new region to the database
        [HttpPost]
        public async Task<ActionResult<Region>> AddRegion(Region Region)
        {
            Region? region = await _RegionService.AddRegions(Region);

            if (region == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error while adding a new region. No changes were made");
            }

            return StatusCode(StatusCodes.Status200OK, region);
        }

        // update existing record matching query
        [HttpPut("id")]
        public async Task<IActionResult> UpdateRegion(int id, Region Region)
        {
            if (id != Region.Id)
            {
                return BadRequest();
            }

            Region? region = await _RegionService.UpdateRegion(Region);

            if (region == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, $"No match");
            }

            return StatusCode(StatusCodes.Status200OK, region);
        }

        // delete individual region matching query 
        [HttpDelete("id")]
        public async Task<IActionResult> DeleteRegion(int id)
        {
            Region? region = await _RegionService.GetRegion(id);

            if(region == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, $"No region matching query");
            }

            await _RegionService.DeleteRegion(region);

            return StatusCode(StatusCodes.Status200OK, $"Region deleted with success");
        }
    
    }


