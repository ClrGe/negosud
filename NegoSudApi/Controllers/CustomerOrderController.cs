﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NegoSudApi.Data;
using NegoSudApi.Models;
using NegoSudApi.Services;
using NegoSudApi.Models.Interfaces;
using NegoSudApi.Services.Interfaces;

namespace NegoSudApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CustomerOrderController : ControllerBase
{
    private readonly ICustomerOrderService _customerOrderService;
    private readonly IVatService _vatService;
    private readonly IConfiguration _configuration;

    public CustomerOrderController(ICustomerOrderService customerOrderService, IVatService vatService,
        IConfiguration configuration)
    {
        _customerOrderService = customerOrderService;
        _vatService = vatService;
        _configuration = configuration;
    }

    [Authorize(Policy = RolePermissions.CanGetCustomerOrder)]
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

    [Authorize(Policy = RolePermissions.CanAddCustomerOrder)]
    [HttpPost("AddCustomerOrder")]
    public async Task<ActionResult<CustomerOrder>> AddCustomerOrder(CustomerOrder customerOrder)
    {
        CustomerOrder? dbCustomerOrder = await _customerOrderService.AddCustomerOrderAsync(customerOrder);

        if (dbCustomerOrder == null)
        {
            return StatusCode(StatusCodes.Status404NotFound, $"{customerOrder.Reference} could not be added.");
        }


        // Create a pfd invoice for the customer if the order can be done immediately
        await GenerateInvoicePdf(customerOrder, dbCustomerOrder);

        return StatusCode(StatusCodes.Status201Created, dbCustomerOrder);
    }


    [Authorize(Policy = RolePermissions.CanEditCustomerOrder)]
    [HttpPost("UpdateCustomerOrder")]
    public async Task<IActionResult> UpdateCustomerOrderAsync(CustomerOrder customerOrder)
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

        // Create a pfd invoice for the customer if the order can be done immediately
        await GenerateInvoicePdf(customerOrder, dbCustomerOrder);
        
        return StatusCode(StatusCodes.Status200OK, dbCustomerOrder);
    }

    [Authorize(Policy = RolePermissions.CanDeleteCustomerOrder)]
    [HttpPost("DeleteCustomerOrder")]
    public async Task<IActionResult> DeleteCustomerOrderAsync(int id)
    {
        bool? status = await _customerOrderService.DeleteCustomerOrderAsync(id);

        if (status == false)
        {
            return StatusCode(StatusCodes.Status404NotFound,
                $"No CustomerOrder found for id: {id} - could not be deleted");
        }

        return StatusCode(StatusCodes.Status200OK);
    }


    /// <summary>
    /// Create a pfd invoice for the customer if the order can be done immediately
    /// </summary>
    /// <param name="customerOrder">The order sent by the e-commerce</param>
    /// <param name="dbCustomerOrder">The order saved in the database</param>
    private async Task GenerateInvoicePdf(CustomerOrder customerOrder, CustomerOrder dbCustomerOrder)
    {
        if (dbCustomerOrder.DeliveryStatus.Value == 1)
        {
            var customerDetails = new List<String>
            {
                customerOrder.Customer.FirstName, customerOrder.Customer.LastName,
                customerOrder.DeliveryAddress.AddressLine1!, customerOrder.DeliveryAddress.AddressLine2!,
                customerOrder.DeliveryAddress.City!.Name!, customerOrder.DeliveryAddress.City.ZipCode.ToString()!
            };

            var negoSudDetails = _configuration.GetSection("NegoSudDetails:Address").Value.Split(" ").ToList();
            List<IOrderLine> customerOrderLines =
                new List<IOrderLine>((dbCustomerOrder.Lines as List<CustomerOrderLine>)!);
            var pdfBytes = new GeneratePdf(customerOrder.Reference!, customerDetails, customerOrderLines,
                negoSudDetails,
                _vatService).SaveInvoice();
            var stream = new MemoryStream(pdfBytes);
            Response.Headers.Add("Content-Disposition", $"inline; filename=invoice_{customerOrder.Reference!}.pdf");
            Response.ContentType = "application/pdf";
            Response.ContentLength = stream.Length;
            await stream.CopyToAsync(Response.Body);
        }
    }
}