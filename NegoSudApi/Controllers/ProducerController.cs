using Microsoft.AspNetCore.Mvc;
using NegoSudApi.Models;
using NegoSudApi.Services;

namespace NegoSudApi.Controllers;



    [ApiController]
    [Route("api/[controller]")]

    public class ProducerController : ControllerBase
    {
        private readonly IProducerService _ProducerService;

        public ProducerController(IProducerService producerService)
        {
            _ProducerService = producerService;
        }


        // method to return a producer matching query
        [HttpGet("id")]
        public async Task<IActionResult> GetProducer(int id)
        {
            Producer? producer = await _ProducerService.GetProducerAsync(id);

            if ( producer== null)
            {
                return StatusCode(StatusCodes.Status204NoContent, $"No match for query");
            }

            return StatusCode(StatusCodes.Status200OK, producer);
        }

        // method to return all existing producers
        [HttpGet]
        public async Task<IActionResult> GetProducers()
        {
            var producers = await _ProducerService.GetProducersAsync();

            if (producers == null)
            {
                return StatusCode(StatusCodes.Status204NoContent, $"No match for query");
            }

            return StatusCode(StatusCodes.Status200OK, producers);
        }

        // method to add a new producer to the database
        [HttpPost]
        public async Task<ActionResult<Producer>> AddProducer(Producer Producer)
        {
            Producer? producer = await _ProducerService.AddProducerAsync(Producer);

            if (producer == null)
            {
                return StatusCode(StatusCodes.Status204NoContent, $"No match for query");
            }

            return StatusCode(StatusCodes.Status200OK, producer);
        }

        // update existing record matching query
        [HttpPut("id")]
        public async Task<IActionResult> UpdateProducer(int id, Producer Producer)
        {
            if (id != Producer.Id)
            {
                return BadRequest();
            }

            Producer? producer = await _ProducerService.UpdateProducerAsync(Producer);

            if (producer == null)
            {
                return StatusCode(StatusCodes.Status204NoContent, $"No match for query");
            }

            return StatusCode(StatusCodes.Status200OK, producer);
        }
        
        // delete individual producer matching query 
        [HttpDelete("id")]
        public async Task<IActionResult> DeleteProducer(int id)
        {
            Producer? producer = await _ProducerService.GetProducerAsync(id);

            if(producer == null)
            {
                return StatusCode(StatusCodes.Status204NoContent, $"No match for query");
            }

            await _ProducerService.DeleteProducerAsync(producer);

            return StatusCode(StatusCodes.Status200OK, $"Producer deleted with success");
        }
    
    }


