using System.Net;
using System.Net.Mail;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NegoSudApi.Models;
using NegoSudApi.Models.Interfaces;
using NegoSudApi.Services;
using NegoSudApi.Services.Interfaces;

namespace NegoSudApi.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class SupplierOrderController : ControllerBase
{
    private readonly ISupplierOrderService _supplierOrderService;
    private readonly IVatService _vatService;
    private readonly ILogger<SupplierOrderController> _logger;
    private readonly IConfiguration _configuration;


    public SupplierOrderController(ISupplierOrderService supplierOrderService, IVatService vatService, ILogger<SupplierOrderController> logger, IConfiguration configuration)
    {
        _supplierOrderService = supplierOrderService;
        _vatService = vatService;
        _logger = logger;
        _configuration = configuration;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetSupplierOrderAsync(int id)
    {
        SupplierOrder? dbSupplierOrder = await _supplierOrderService.GetSupplierOrderAsync(id);

        if (dbSupplierOrder == null)
        {
            return StatusCode(StatusCodes.Status404NotFound, $"No supplier order found for id: {id}");
        }

        return StatusCode(StatusCodes.Status200OK, dbSupplierOrder);
    }

    [HttpGet]
    public async Task<IActionResult> GetSupplierOrdersAsync()
    {
        var dbSupplierOrders = await _supplierOrderService.GetSupplierOrdersAsync();

        if (dbSupplierOrders == null)
        {
            return StatusCode(StatusCodes.Status404NotFound, "No supplier orders in database");
        }

        return StatusCode(StatusCodes.Status200OK, dbSupplierOrders);
    }

    [HttpPost("AddSupplierOrder")]
    public async Task<ActionResult<SupplierOrder>> AddSupplierOrder(SupplierOrder supplierOrder)
    {
        SupplierOrder? dbSupplierOrder = await _supplierOrderService.AddSupplierOrderAsync(supplierOrder);

        if (dbSupplierOrder == null)
        {
            return StatusCode(StatusCodes.Status404NotFound, $"{supplierOrder.Reference} could not be added.");
        }

        List<IOrderLine> customerOrderLines = new List<IOrderLine>((dbSupplierOrder.Lines as List<SupplierOrderLine>)!);

        var negoSudDetails = new List<string> {"NegoSud", "80 avenue Edmund Halley", "Saint-Étienne-du-Rouvray", "76800", "France"};
        var pdfPath = new GeneratePdf(supplierOrder.Reference, negoSudDetails,customerOrderLines, _vatService).SaveLocally();
        var sendEmail = this.SendEmailWithAttachment("negosud", supplierOrder.Supplier.Email, $"Bon de commande", pdfPath, _configuration);
        
        return sendEmail ? StatusCode(StatusCodes.Status201Created, dbSupplierOrder + "Commande envoyée au fournisseur") : StatusCode(StatusCodes.Status201Created, dbSupplierOrder + "Commande NON envoyée au fournisseur ");
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
            return StatusCode(StatusCodes.Status404NotFound, $"No Supplier Order found for id: {supplierOrder.Id} - could not update.");
        }

        return StatusCode(StatusCodes.Status200OK, dbSupplierOrder);
    }

    [HttpPost("DeleteSupplierOrder")]
    public async Task<IActionResult> DeleteSupplierOrderAsync([FromBody]int id)
    {
        bool? status = await _supplierOrderService.DeleteSupplierOrderAsync(id);

        if (status == false)
        {
            return StatusCode(StatusCodes.Status404NotFound, $"No Supplier Order found for id: {id} - could not be deleted");
        }

        return StatusCode(StatusCodes.Status200OK);
    }
    
    private bool SendEmailWithAttachment(string from, string to, string subject, string filePathToAttach, IConfiguration configuration)
    {
        string htmlBody = "<html><body><p>Bonjour,</p>" +
                          "<p>Nous souhaiterions vous commande les références ci jointes,</p>" +
                          "<p>Bien à vous,</p></body></html>";

        var message = new MailMessage(from, to)
        {
            Subject = subject,
            Body = htmlBody,
            IsBodyHtml = true 
        };
    
        // Add the PDF file as an attachment
        var attachment = new Attachment(filePathToAttach);
        message.Attachments.Add(attachment);
        

        var emailSettings = configuration.GetSection("EmailSettings");
        var emailUsername = emailSettings.GetValue<string>("Username");
        var emailPassword = emailSettings.GetValue<string>("Password");

    
        var client = new SmtpClient("smtp.gmail.com", 587) 
        {
            Credentials = new NetworkCredential(emailUsername, emailPassword),
            EnableSsl = true
        };
    
        try
        {
            client.Send(message);
            return true;
        }
        catch (Exception ex)
        {
            _logger.Log( LogLevel.Warning, "Error sending email: {ExceptionMessage}", ex.Message);
            return false;
        }
      
    }
}