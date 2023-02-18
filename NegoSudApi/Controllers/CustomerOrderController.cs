﻿using Microsoft.AspNetCore.Authorization;
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
    public async Task<ActionResult<CustomerOrder>> AddCustomerOrder(CustomerOrder customerOrder, Address addressToDeliver)
    {
        CustomerOrder? dbCustomerOrder = await _customerOrderService.AddCustomerOrderAsync(customerOrder);

        if (dbCustomerOrder == null)
        {
            return StatusCode(StatusCodes.Status404NotFound, $"{customerOrder.Reference} could not be added.");
        }

        var customerDetails = new List<String>
        {
            addressToDeliver.Label!, addressToDeliver.FirstLine!, addressToDeliver.City!.Name!, addressToDeliver.City.ZipCode.ToString()!
        };
        
        var pdfBytes = new GeneratePdf(customerOrder.Reference!, customerDetails, (customerOrder.Lines as List<CustomerOrderLine>)!).Save();
        var stream = new MemoryStream(pdfBytes);
        Response.Headers.Add("Content-Disposition", $"inline; filename=invoice_{customerOrder.Reference!}.pdf");
        Response.ContentType = "application/pdf";
        

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