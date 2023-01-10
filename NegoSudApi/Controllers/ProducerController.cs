using Microsoft.AspNetCore.Mvc;
using NegoSudApi.Models;
using NegoSudApi.Services;

namespace NegoSudApi.Controllers

{

    [ApiController]
    [Route("api/[controller]")]

    public class ProducerController : ControllerBase
    {
        private readonly IProducerService _ProducerService;

        public ProducerController(IProducerService producerService)
        {
            _producerProducer = producerService;
        }


// method to return a producer matching query

        [HttpGet("id")]
        public async Task<IActionResult> GetProducer(int id)
        {
            Producer? producer = await _producerProducer.GetProducer(id);

            if ( == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, $"404 No match for query");
            }

            return StatusCode(StatusCodes.Status200OK, producer);
        }

// method to return all existing producers
        [HttpGet]
        public async Task<IActionResult> GetProducers()
        {
            var producers = await _producerProducer.GetProducers();

            if (producers == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, "Oops, no match");
            }

            return StatusCode(StatusCodes.Status200OK, producers);
        }

// method to add a new producer to the database

        [HttpPost]
        public async Task<ActionResult<Producer>> AddProducer(Producer Producer)
        {
            Producer? producer = await _producerProducer.AddProducer(Producer);

            if (producer == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error while adding a new producer. No changes were made");
            }

            return StatusCode(StatusCodes.Status200OK, grape);
        }

// update existing record matching query

        [HttpPut("id")]
        public async Task<IActionResult> UpdateProducer(int id, Producer Producer)
        {
            if (id != Producer.Id)
            {
                return BadRequest();
            }

            Producer? producer = await _producerProducer.UpdateProducer(Producer);

            if (producer == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, $"No match");
            }

            return StatusCode(StatusCodes.Status200OK, producer);
        }

// delete individual producer matching query 

        [HttpDelete("id")]
        public async Task<IActionResult> DeleteProducer(int id)
        {
            Producer? producer = await _producerProducer.GetProducer(id);

            if(producer == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, $"No producer matching query");
            }

            await _producerProducer.DeleteProducer(id);

            return StatusCode(StatusCodes.Status200OK, $"Producer deleted with success");
        }
    
    }

}
