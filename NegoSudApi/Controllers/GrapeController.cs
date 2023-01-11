using Microsoft.AspNetCore.Mvc;
using NegoSudApi.Models;
using NegoSudApi.Services;

namespace NegoSudApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
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
            Grape? grape = await _grapeService.GetGrapeAsync(id);
            if (grape == null)
            {
                return StatusCode(StatusCodes.Status204NoContent, $"No match for query");
            }
            return StatusCode(StatusCodes.Status200OK, grape);
        }

        [HttpGet]
        public async Task<IActionResult> GetGrapesAsync()
        {
            IEnumerable<Grape>? grapes = await _grapeService.GetGrapesAsync();
            if (grapes == null)
            {
                return StatusCode(StatusCodes.Status204NoContent, $"No match for query");
            }
            return StatusCode(StatusCodes.Status200OK, grapes.ToList());
        }

        [HttpPost]
        public async Task<IActionResult> AddGrapeAsync(Grape model)
        {
            Grape? grape = await _grapeService.AddGrapeAsync(model);
            if (grape == null)
            {
                return StatusCode(StatusCodes.Status204NoContent, $"No match for query");
            }
            return StatusCode(StatusCodes.Status200OK, grape);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateGrapeAsync(int id, Grape model)
        {
            if (id != model.Id)
            {
                return BadRequest();
            }

            Grape? grape = await _grapeService.UpdateGrapeAsync(model);
            if (grape == null)
            {
                return StatusCode(StatusCodes.Status204NoContent, $"No match for query");
            }
            return StatusCode(StatusCodes.Status200OK, grape);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGrapeAsync(int id)
        {
            Grape? grape = await _grapeService.GetGrapeAsync(id);
            if (grape == null)
            {
                return StatusCode(StatusCodes.Status204NoContent, $"No match for query");
            }
            await _grapeService.DeleteGrapeAsync(id);
            return StatusCode(StatusCodes.Status200OK);
        }

        [HttpGet("bottles/{id}")]
        public async Task<IActionResult> GetBottlesAsync(int id)
        {
            Grape? grape = await _grapeService.GetGrapeAsync(id);
            if (grape == null)
            {
                return StatusCode(StatusCodes.Status204NoContent, $"No match for query");
            }
            IEnumerable<Bottle>? bottles = await _grapeService.GetBottlesAsync(id);
            if (bottles == null)
            {
                return StatusCode(StatusCodes.Status204NoContent, $"No match for query");
            }
            return StatusCode(StatusCodes.Status200OK, bottles);
        }

        [HttpGet("bottleGrapes/{id}")]
        public async Task<IActionResult> GetBottleGrapesAsync(int id)
        {
            Grape? grape = await _grapeService.GetGrapeAsync(id);
            if (grape == null)
            {
                return StatusCode(StatusCodes.Status204NoContent, $"No match for query");
            }
            IEnumerable<BottleGrape>? bottleGrapes = await _grapeService.GetBottleGrapesAsync(id);
            if (bottleGrapes == null)
            {
                return StatusCode(StatusCodes.Status204NoContent, $"No match for query");
            }
            return StatusCode(StatusCodes.Status200OK, bottleGrapes);
        }
    }
}
