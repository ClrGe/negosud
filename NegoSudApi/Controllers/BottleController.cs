using Microsoft.AspNetCore.Mvc;
using NegoSudApi.Models;
using NegoSudApi.Services;

namespace NegoSudApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BottleController : ControllerBase
    {
        private readonly IBottleService _bottleService;

        public BottleController(IBottleService bottleService)
        {
            _bottleService = bottleService;
        }

        [HttpGet]
        public async Task<IActionResult> GetBottlesAsync()
        {
            var bottles = await _bottleService.GetBottlesAsync();

            if (bottles == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, "No bottles in database");
            }

            return StatusCode(StatusCodes.Status200OK, bottles);
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetBottleAsync(int id)
        {
            Bottle? bottle = await _bottleService.GetBottleAsync(id);

            if (bottle == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, $"No Bottle found for id: {id}");
            }

            return StatusCode(StatusCodes.Status200OK, bottle);
        }

        [HttpPost]
        public async Task<ActionResult<Bottle>> AddBottleAsync(Bottle Bottle)
        {
            var dbBottle = await _bottleService.AddBottleAsync(Bottle);

            if (dbBottle == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"{Bottle.Full_Name} could not be added.");
            }

            return CreatedAtAction("GetBottle", new { id = Bottle.Id }, Bottle);
        }

        [HttpPut("id")]
        public async Task<IActionResult> UpdateBottleAsync(int id, Bottle bottle)
        {
            if (id != bottle.Id)
            {
                return BadRequest();
            }

            Bottle? dbBottle = await _bottleService.UpdateBottleAsync(bottle);

            if (dbBottle == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"{bottle.Full_Name} could not be updated");
            }

            return NoContent();
        }

        [HttpDelete("id")]
        public async Task<IActionResult> DeleteBottleAsync(int id)
        {
            bool? status = await _bottleService.DeleteBottleAsync(id);

            if (status == false)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"{bottle.Full_Name} could not be deleted");
            }

            return StatusCode(StatusCodes.Status200OK);
        }
    }
}