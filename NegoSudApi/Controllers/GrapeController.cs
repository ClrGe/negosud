using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NegoSudApi.Models;
using NegoSudApi.Services.Interfaces;

namespace NegoSudApi.Controllers
{
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
                return StatusCode(StatusCodes.Status204NoContent, $"No match for query");
            }
            return StatusCode(StatusCodes.Status200OK, dbGrape);
        }

        [HttpGet]
        public async Task<IActionResult> GetGrapesAsync()
        {
            IEnumerable<Grape>? dbGrapes = await _grapeService.GetGrapesAsync();
            if (dbGrapes == null)
            {
                return StatusCode(StatusCodes.Status204NoContent, $"No match for query");
            }
            return StatusCode(StatusCodes.Status200OK, dbGrapes.ToList());
        }

        [HttpPost("AddGrape")]
        public async Task<IActionResult> AddGrapeAsync(Grape grape)
        {
            Grape? dbGrape = await _grapeService.AddGrapeAsync(grape);
            if (dbGrape == null)
            {
                return StatusCode(StatusCodes.Status204NoContent, $"No match for query");
            }
            return StatusCode(StatusCodes.Status201Created, dbGrape);
        }

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
                return StatusCode(StatusCodes.Status204NoContent, $"No Country found for id: {grape.Id} - could not update.");
            }
            return StatusCode(StatusCodes.Status200OK, dbGrape);
        }

        [HttpPost("DeleteGrape")]
        public async Task<IActionResult> DeleteGrapeAsync(int id)
        {
            Grape? dbGrape = await _grapeService.GetGrapeAsync(id);
            if (dbGrape == null)
            {
                return StatusCode(StatusCodes.Status204NoContent, $"No match for query");
            }
            await _grapeService.DeleteGrapeAsync(id);
            return StatusCode(StatusCodes.Status200OK);
        }

    }
}
