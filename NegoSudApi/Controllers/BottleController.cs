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
        public async Task<IActionResult> GetBottles()
        {
            var bottles = await _bottleService.GetBottlesAsync();

            if (bottles == null)
            {
                return StatusCode(StatusCodes.Status204NoContent, "No bottles in database");
            }

            return StatusCode(StatusCodes.Status200OK, bottles);
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetBottle(int id)
        {
            Bottle? bottle = await _bottleService.GetBottleAsync(id);

            if (bottle == null)
            {
                return StatusCode(StatusCodes.Status204NoContent, $"No Bottle found for id: {id}");
            }

            return StatusCode(StatusCodes.Status200OK, bottle);
        }

        [HttpPost]
        public async Task<ActionResult<Bottle> AddBottle(Bottle Bottle)
        {
            Bottle? bottle = await _bottleService.AddBottleAsync(Bottle);

            if (bottle == null)
            {
                return StatusCode(StatusCodes.Status204NoContent, $"{Bottle.Full_Name} could not be added.");
            }

            return CreatedAtAction("GetBottle", new { id = Bottle.Id }, Bottle);
        }

        [HttpPut("id")]
        public async Task<IActionResult> UpdateBottle(int id, Bottle Bottle)
        {
            if (id != Bottle.Id)
            {
                return BadRequest();
            }

            Bottle? dbBottle = await _bottleService.UpdateBottleAsync(Bottle);

            if (dbBottle == null)
            {
                return StatusCode(StatusCodes.Status204NoContent, $"No match for query - could not update");
            }

            return NoContent();
        }

        [HttpDelete("id")]
        public async Task<IActionResult> DeleteBottle(int id)
        {
            var Bottle = await _bottleService.GetBottleAsync(id);
            bool? status = await _bottleService.DeleteBottleAsync(Bottle);

            if (status == false)
            {
                return StatusCode(StatusCodes.Status204NoContent, $"{Bottle.Full_Name} could not be deleted");
            }

            return StatusCode(StatusCodes.Status200OK);
        }
    }
}