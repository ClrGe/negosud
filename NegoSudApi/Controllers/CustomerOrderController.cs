using Microsoft.AspNetCore.Mvc;
using NegoSudApi.Models;
using NegoSudApi.Services.Interfaces;

namespace NegoSudApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerOrderController : ControllerBase
    {
        private readonly ICustomerOrderService _customerOrderService;

        public CustomerOrderController(ICustomerOrderService customerOrderService)
        {
            _customerOrderService = customerOrderService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomerOrderAsync(int id)
        {
            CustomerOrder? dbCustomerOrder = await _customerOrderService.GetCustomerOrderAsync(id);

            if (dbCustomerOrder == null)
            {
                return StatusCode(StatusCodes.Status204NoContent, $"No customerOrder found for id: {id}");
            }

            return StatusCode(StatusCodes.Status200OK, dbCustomerOrder);
        }

        [HttpGet]
        public async Task<IActionResult> GetCustomerOrdersAsync()
        {
            var dbCustomerOrders = await _customerOrderService.GetCustomerOrdersAsync();

            if (dbCustomerOrders == null)
            {
                return StatusCode(StatusCodes.Status204NoContent, "No customerOrders in database");
            }

            return StatusCode(StatusCodes.Status200OK, dbCustomerOrders);
        }

        [HttpPost]
        public async Task<ActionResult<CustomerOrder>> AddCustomerOrder(CustomerOrder customerOrder)
        {
            CustomerOrder? dbCustomerOrder = await _customerOrderService.AddCustomerOrderAsync(customerOrder);

            if (dbCustomerOrder == null)
            {
                return StatusCode(StatusCodes.Status204NoContent, $"{customerOrder.Reference} could not be added.");
            }

            return StatusCode(StatusCodes.Status201Created, dbCustomerOrder);
        }

        //[HttpPost]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCustomerOrderAsync(int id, CustomerOrder customerOrder)
        {
            if (id != customerOrder.Id)
            {
                return BadRequest();
            }

            CustomerOrder? dbCustomerOrder = await _customerOrderService.UpdateCustomerOrderAsync(customerOrder);

            if (dbCustomerOrder == null)
            {
                return StatusCode(StatusCodes.Status204NoContent, $"No match for query - could not update");
            }

            return StatusCode(StatusCodes.Status200OK, dbCustomerOrder);
        }

        //[HttpPost]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomerOrderAsync(int id)
        {
            bool? status = await _customerOrderService.DeleteCustomerOrderAsync(id);

            if (status == false)
            {
                return StatusCode(StatusCodes.Status204NoContent, $"No CustomerOrder found for id: {id} - could not be deleted");
            }

            return StatusCode(StatusCodes.Status200OK);
        }
    }
}