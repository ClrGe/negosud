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

        [HttpGet("id")]
        public async Task<IActionResult> GetGrape(int grapeId)
        {
            Grape? grape = await _grapeService.GetGrape(grapeId);
            if(grape == null)
            {
                return StatusCode(StatusCodes.Status404NotFound);
            }
            return StatusCode(StatusCodes.Status200OK, grape);            
        }

        [HttpGet]
        public async Task<IActionResult> GetGrapes()
        {
            IEnumerable<Grape>? grapes = await _grapeService.GetGrapes();
            if(grapes == null)
            {
                return StatusCode(StatusCodes.Status404NotFound);
            }
            return StatusCode(StatusCodes.Status200OK, grapes.ToList());
        }

        [HttpPost]
        public async Task<IActionResult> PostGrape(Grape model)
        {
            Grape? grape = await _grapeService.PostGrape(model);
            if(grape == null)
            {
                return StatusCode(StatusCodes.Status404NotFound);
            }
            return StatusCode(StatusCodes.Status200OK, grape);
        }

        [HttpPut("id")]
        public async Task<IActionResult> PutGrape(int grapeId, Grape model)
        {
            if(grapeId != model.Id)
            {
                return BadRequest();
            }

            Grape? grape = await _grapeService.PutGrape(model);
            if (grape == null)
            {
                return StatusCode(StatusCodes.Status404NotFound);
            }
            return StatusCode(StatusCodes.Status200OK, grape);
        }

        [HttpDelete("id")]
        public async Task<IActionResult> DeleteGrape(int grapeId)
        {
            Grape? grape = await _grapeService.GetGrape(grapeId);
            if(grape == null)
            {
                return StatusCode(StatusCodes.Status404NotFound);
            }
            await _grapeService.DeleteGrape(grapeId);
            return StatusCode(StatusCodes.Status200OK);
        }

        [HttpGet("bottles/{id}")]
        public async Task<IActionResult> GetBottles(int grapeId)
        {
            Grape? grape = await _grapeService.GetGrape(grapeId);
            if (grape == null)
            {
                return StatusCode(StatusCodes.Status404NotFound);
            }
            IEnumerable<Bottle>? bottles = await _grapeService.GetBottles(grapeId);
            if(bottles == null)
            {
                return StatusCode(StatusCodes.Status404NotFound);
            }
            return StatusCode(StatusCodes.Status200OK, bottles);
        }

        [HttpGet("bottleGrapes/{id}")]
        public async Task<IActionResult> GetBottleGrapes(int grapeId)
        {
            Grape? grape = await _grapeService.GetGrape(grapeId);
            if (grape == null)
            {
                return StatusCode(StatusCodes.Status404NotFound);
            }
            IEnumerable<BottleGrape>? bottleGrapes = await _grapeService.GetBottleGrapes(grapeId);
            if (bottleGrapes == null)
            {
                return StatusCode(StatusCodes.Status404NotFound);
            }
            return StatusCode(StatusCodes.Status200OK, bottleGrapes);
        }
    }
}
