using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NegoSudApi.Models;
using NegoSudApi.Services.Interfaces;

namespace NegoSudApi.Controllers
{
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
            Bottle? dbBottle = await _bottleService.GetBottleAsync(id);

            if (dbBottle == null)
            {
                return StatusCode(StatusCodes.Status204NoContent, $"No Bottle found for id: {id}");
            }

            return StatusCode(StatusCodes.Status200OK, dbBottle);
        }

        [HttpGet]
        public async Task<IActionResult> GetBottlesAsync()
        {
            var dbBottles = await _bottleService.GetBottlesAsync();

            if (dbBottles == null)
            {
                return StatusCode(StatusCodes.Status204NoContent, "No bottles in database");
            }

            return StatusCode(StatusCodes.Status200OK, dbBottles);
        }

        [HttpPost]
        public async Task<ActionResult<Bottle>> AddBottle(Bottle bottle)
        {
            Bottle? dbBottle = await _bottleService.AddBottleAsync(bottle);

            if (dbBottle == null)
            {
                return StatusCode(StatusCodes.Status204NoContent, $"{bottle.FullName} could not be added.");
            }

            return StatusCode(StatusCodes.Status201Created, dbBottle);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBottleAsync(int id, Bottle bottle)
        {
            if (id != bottle.Id)
            {
                return BadRequest();
            }

            Bottle? dbBottle = await _bottleService.UpdateBottleAsync(bottle);

            if (dbBottle == null)
            {
                return StatusCode(StatusCodes.Status204NoContent, $"No match for query - could not update");
            }

            return StatusCode(StatusCodes.Status200OK, dbBottle);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBottleAsync(int id)
        {
            bool? status = await _bottleService.DeleteBottleAsync(id);

            if (status == false)
            {
                return StatusCode(StatusCodes.Status204NoContent, $"No Bottle found for id: {id} - could not be deleted");
            }

            return StatusCode(StatusCodes.Status200OK);
        }
    }
}