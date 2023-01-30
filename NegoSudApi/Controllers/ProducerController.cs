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

    
    /// <summary>
    /// Method to return a producer matching query
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
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

    /// <summary>
    /// Method to return all existing producers
    /// </summary>
    /// <returns></returns>
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

    
    /// <summary>
    /// Method to add a new producer to the database
    /// </summary>
    /// <param name="producer"></param>
    /// <returns></returns>
    [HttpPost("AddProducer")]
    public async Task<ActionResult<Producer>> AddProducerAsync(Producer producer)
    {
        Producer? dbProducer = await _producerService.AddProducerAsync(producer);

        if (dbProducer == null)
        {
            return StatusCode(StatusCodes.Status204NoContent, $"No match for query");
        }

        return StatusCode(StatusCodes.Status201Created, dbProducer);
    }

    
    /// <summary>
    /// update existing record matching query
    /// </summary>
    /// <param name="id"></param>
    /// <param name="producer"></param>
    /// <returns></returns>
    [HttpPost("UpdateProducer")]
    public async Task<IActionResult> UpdateProducerAsync(Producer producer)
    {
        if (producer == null)
        {
            return BadRequest();
        }

        Producer? dbProducer = await _producerService.UpdateProducerAsync(producer);

        if (dbProducer == null)
        {
            return StatusCode(StatusCodes.Status204NoContent, $"No Country found for id: {producer.Id} - could not update.");
        }

        return StatusCode(StatusCodes.Status200OK, dbProducer);
    }
    
    
    /// <summary>
    /// Delete individual producer matching query
    /// </summary>
    /// <param name="id">The producer's id to delete</param>
    /// <returns>Status code</returns>
    [HttpPost("DeleteProducer")]
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


