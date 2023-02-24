using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NegoSudApi.Models;
using NegoSudApi.Services;
using NegoSudApi.Services.Interfaces;

namespace NegoSudApi.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class CustomerOrderController : ControllerBase
{
    private readonly ICustomerOrderService _customerOrderService;
    private readonly IVatService _vatService;

    public CustomerOrderController(ICustomerOrderService customerOrderService, IVatService vatService)
    {
        _customerOrderService = customerOrderService;
        _vatService = vatService;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetCustomerOrderAsync(int id)
    {
        CustomerOrder? dbCustomerOrder = await _customerOrderService.GetCustomerOrderAsync(id);

        if (dbCustomerOrder == null)
        {
            return StatusCode(StatusCodes.Status404NotFound, $"No customerOrder found for id: {id}");
        }

        return StatusCode(StatusCodes.Status200OK, dbCustomerOrder);
    }

    [HttpGet]
    public async Task<IActionResult> GetCustomerOrdersAsync()
    {
        var dbCustomerOrders = await _customerOrderService.GetCustomerOrdersAsync();

        if (dbCustomerOrders == null)
        {
            return StatusCode(StatusCodes.Status404NotFound, "No customerOrders in database");
        }

        return StatusCode(StatusCodes.Status200OK, dbCustomerOrders);
    }

    [HttpPost("AddCustomerOrder")]
    public async Task<ActionResult<CustomerOrder>> AddCustomerOrder(CustomerOrder customerOrder)
    {
        CustomerOrder? dbCustomerOrder = await _customerOrderService.AddCustomerOrderAsync(customerOrder);

        if (dbCustomerOrder == null)
        {
            return StatusCode(StatusCodes.Status404NotFound, $"{customerOrder.Reference} could not be added.");
        }
        
        var customerDetails = new List<String>
        {
            customerOrder.Customer.FirstName, customerOrder.Customer.LastName, customerOrder.DeliveryAddress.Label!, customerOrder.DeliveryAddress.FirstLine!, customerOrder.DeliveryAddress.City!.Name!, customerOrder.DeliveryAddress.City.ZipCode.ToString()!
        };
        
        // Create a pfd invoice for the customer
        var pdfBytes = new GeneratePdf(customerOrder.Reference!, customerDetails, (dbCustomerOrder.Lines as List<CustomerOrderLine>)!, _vatService).Save();
        var stream = new MemoryStream(pdfBytes);
        Response.Headers.Add("Content-Disposition", $"inline; filename=invoice_{customerOrder.Reference!}.pdf");
        Response.ContentType = "application/pdf";
        Response.ContentLength = stream.Length;
        await stream.CopyToAsync(Response.Body);

        return StatusCode(StatusCodes.Status201Created, dbCustomerOrder);
    }

    [HttpPost("UpdateCustomerOrder")]
    public async Task<IActionResult> UpdateCustomerOrderAsync(CustomerOrder? customerOrder)
    {
        if (customerOrder == null)
        {
            return BadRequest();
        }

        CustomerOrder? dbCustomerOrder = await _customerOrderService.UpdateCustomerOrderAsync(customerOrder);

        if (dbCustomerOrder == null)
        {
            return StatusCode(StatusCodes.Status404NotFound, $"No match for query - could not update");
        }

        return StatusCode(StatusCodes.Status200OK, dbCustomerOrder);
    }

    [HttpPost("DeleteCustomerOrder")]
    public async Task<IActionResult> DeleteCustomerOrderAsync(int id)
    {
        bool? status = await _customerOrderService.DeleteCustomerOrderAsync(id);

        if (status == false)
        {
            return StatusCode(StatusCodes.Status404NotFound, $"No CustomerOrder found for id: {id} - could not be deleted");
        }

        return StatusCode(StatusCodes.Status200OK);
    }
}