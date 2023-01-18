using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NegoSudApi.Models;
using NegoSudApi.Services.Interfaces;

namespace NegoSudApi.Controllers;



[ApiController]
[Route("api/[controller]")]
[Authorize]
public class ProducerController : ControllerBase
{
    private readonly IProducerService _producerService;

    public ProducerController(IProducerService producerService)
    {
        _producerService = producerService;
    }

    // method to return a producer matching query
    [HttpGet("{id}")]
    public async Task<IActionResult> GetProducerAsync(int id)
    {
        Producer? dbProducer = await _producerService.GetProducerAsync(id);

        if (dbProducer == null)
        {
            return StatusCode(StatusCodes.Status204NoContent, $"No match for query");
        }

        return StatusCode(StatusCodes.Status200OK, dbProducer);
    }

    // method to return all existing producers
    [HttpGet]
    public async Task<IActionResult> GetProducersAsync()
    {
        IEnumerable<Producer>? dbProducers = await _producerService.GetProducersAsync();

        if (dbProducers == null)
        {
            return StatusCode(StatusCodes.Status204NoContent, $"No match for query");
        }

        return StatusCode(StatusCodes.Status200OK, dbProducers);
    }

    // method to add a new producer to the database
    [HttpPost]
    public async Task<ActionResult<Producer>> AddProducerAsync(Producer producer)
    {
        Producer? dbProducer = await _producerService.AddProducerAsync(producer);

        if (dbProducer == null)
        {
            return StatusCode(StatusCodes.Status204NoContent, $"No match for query");
        }

        return StatusCode(StatusCodes.Status201Created, dbProducer);
    }

    // update existing record matching query
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateProducerAsync(int id, Producer producer)
    {
        if (id != producer.Id)
        {
            return BadRequest();
        }

        Producer? dbProducer = await _producerService.UpdateProducerAsync(producer);

        if (dbProducer == null)
        {
            return StatusCode(StatusCodes.Status204NoContent, $"No match for query");
        }

        return StatusCode(StatusCodes.Status200OK, dbProducer);
    }

    // delete individual producer matching query 
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProducerAsync(int id)
    {
        Producer? producer = await _producerService.GetProducerAsync(id);

        if (producer == null)
        {
            return StatusCode(StatusCodes.Status204NoContent, $"No match for query");
        }

        await _producerService.DeleteProducerAsync(id);

        return StatusCode(StatusCodes.Status200OK, $"Producer deleted with success");
    }

}


