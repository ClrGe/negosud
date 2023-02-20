using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NegoSudApi.Models;
using NegoSudApi.Services.Interfaces;

namespace NegoSudApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class SupplierOrderController : ControllerBase
    {
        private readonly ISupplierOrderService _supplierOrderService;

        public SupplierOrderController(ISupplierOrderService supplierOrderService)
        {
            _supplierOrderService = supplierOrderService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSupplierOrderAsync(int id)
        {
            SupplierOrder? dbSupplierOrder = await _supplierOrderService.GetSupplierOrderAsync(id);

            if (dbSupplierOrder == null)
            {
                return StatusCode(StatusCodes.Status204NoContent, $"No supplierOrder found for id: {id}");
            }

            return StatusCode(StatusCodes.Status200OK, dbSupplierOrder);
        }

        [HttpGet]
        public async Task<IActionResult> GetSupplierOrdersAsync()
        {
            var dbSupplierOrders = await _supplierOrderService.GetSupplierOrdersAsync();

            if (dbSupplierOrders == null)
            {
                return StatusCode(StatusCodes.Status204NoContent, "No supplierOrders in database");
            }

            return StatusCode(StatusCodes.Status200OK, dbSupplierOrders);
        }

        [HttpPost("AddSupplierOrder")]
        public async Task<ActionResult<SupplierOrder>> AddSupplierOrder(SupplierOrder supplierOrder)
        {
            SupplierOrder? dbSupplierOrder = await _supplierOrderService.AddSupplierOrderAsync(supplierOrder);

            if (dbSupplierOrder == null)
            {
                return StatusCode(StatusCodes.Status204NoContent, $"{supplierOrder.Reference} could not be added.");
            }

            return StatusCode(StatusCodes.Status201Created, dbSupplierOrder);
        }

        [HttpPost("UpdateSupplierOrder")]
        public async Task<IActionResult> UpdateSupplierOrderAsync(SupplierOrder supplierOrder)
        {
            if (supplierOrder == null)
            {
                return BadRequest();
            }

            SupplierOrder? dbSupplierOrder = await _supplierOrderService.UpdateSupplierOrderAsync(supplierOrder);

            if (dbSupplierOrder == null)
            {
                return StatusCode(StatusCodes.Status204NoContent, $"No SupplierOrder found for id: {supplierOrder.Id} - could not update.");
            }

            return StatusCode(StatusCodes.Status200OK, dbSupplierOrder);
        }

        [HttpPost("DeleteSupplierOrder")]
        public async Task<IActionResult> DeleteSupplierOrderAsync(int id)
        {
            bool? status = await _supplierOrderService.DeleteSupplierOrderAsync(id);

            if (status == false)
            {
                return StatusCode(StatusCodes.Status204NoContent, $"No SupplierOrder found for id: {id} - could not be deleted");
            }

            return StatusCode(StatusCodes.Status200OK);
        }
    }
}