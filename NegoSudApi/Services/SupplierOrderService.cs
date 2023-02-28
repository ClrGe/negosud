using Aspose.Pdf.Operators;
using Microsoft.EntityFrameworkCore;
using NegoSudApi.Data;
using NegoSudApi.Models;
using NegoSudApi.Models.Interfaces;
using NegoSudApi.Services.Interfaces;

namespace NegoSudApi.Services;

public class SupplierOrderService : ISupplierOrderService
{
    private readonly NegoSudDbContext _context;
    private readonly ILogger<SupplierOrderService> _logger;
    private readonly ISupplierService _supplierService;
    private readonly IBottleService _bottleService;
    private readonly IConfiguration _configuration;
    private readonly IEmailService _emailService;
    private readonly IVatService _vatService;


    public SupplierOrderService(NegoSudDbContext context,
        ILogger<SupplierOrderService> logger,
        ISupplierService supplierService,
        IBottleService bottleService, IConfiguration configuration, IEmailService emailService, IVatService vatService)
    {
        _context = context;
        _logger = logger;
        _supplierService = supplierService;
        _bottleService = bottleService;
        _configuration = configuration;
        _emailService = emailService;
        _vatService = vatService;
    }

    //</inheritdoc>  
    public async Task<SupplierOrder?> GetSupplierOrderAsync(int id, bool includeRelations = true)
    {
        try
        {
            if (includeRelations)
            {
                return await _context.SupplierOrders
                    .Include(sO => sO.Supplier)
                    .Include(sO => sO.Lines)
                    .ThenInclude(l => l.Bottle)
                    .FirstOrDefaultAsync(cO => cO.Id == id);
            }

            return await _context.SupplierOrders.FindAsync(id);
        }
        catch (Exception ex)
        {
            _logger.Log(LogLevel.Information, ex.ToString());
        }

        return null;
    }

    //</inheritdoc>  
    public async Task<IEnumerable<SupplierOrder>?> GetSupplierOrdersAsync()
    {
        try
        {
            return await _context.SupplierOrders.ToListAsync();
        }
        catch (Exception ex)
        {
            _logger.Log(LogLevel.Information, ex.ToString());
        }

        return null;
    }

    //</inheritdoc>  
    public async Task<SupplierOrder?> AddSupplierOrderAsync(SupplierOrder supplierOrder)
    {
        try
        {
            if(supplierOrder.Supplier?.Id != null)
            {
                Supplier? dbSupplier = await _supplierService.GetSupplierAsync(supplierOrder.Supplier.Id);
                if (dbSupplier != null)
                {
                    supplierOrder.Supplier = dbSupplier;
                }
            }

            
            //SupplierOrder newSupplierOrder = new SupplierOrder
            //{
            //    Description = supplierOrder.Description,
            //    Supplier = supplierOrder.Supplier,
            //};

            if(supplierOrder.Lines != null)
            {
                foreach (SupplierOrderLine orderLine in supplierOrder.Lines)
                {
                    if (orderLine.BottleId == null) continue;
                    Bottle? dbBottle = await _bottleService.GetBottleAsync((int) orderLine.BottleId);
                    if (dbBottle != null)
                    {
                        orderLine.Bottle = dbBottle;
                    }

                    // set the SupplierOrderId for the SupplierOrderLine
                    //orderLine.SupplierOrder = newSupplierOrder;
                    orderLine.SupplierOrder = supplierOrder;
                }

                await _context.AddRangeAsync(supplierOrder.Lines);

            }

            supplierOrder.DeliveryStatus = DeliveryStatus.Pending.GetHashCode();

            await _context.SaveChangesAsync();

            //try
            //{
            //    await SendPurchaseOrder(supplierOrder);
            //}
            //catch (Exception ex)
            //{
            //    _logger.Log(LogLevel.Information, ex.ToString());
            //}

            //return newSupplierOrder;
            return supplierOrder;

        }
        catch (Exception ex)
        {
            _logger.Log(LogLevel.Information, ex.ToString());
        }

        return null;
    }

    /// <summary>
    /// Sends a purchase order to a supplier and saves a copy of the purchase order as a PDF.
    /// </summary>
    /// <param name="supplierOrder">The SupplierOrder object containing the order information.</param>
    /// <returns>A Task representing the asynchronous operation.</returns>
    /// <remarks>
    /// This method generates a PDF file containing the purchase order information, and sends it to the supplier's email address
    /// specified in the SupplierOrder object using the EmailService. The email subject is "Bon de commande".
    /// The PDF file is saved locally using the GeneratePdf class, and is deleted after the email is successfully sent.
    /// </remarks>
    private async Task SendPurchaseOrder(SupplierOrder supplierOrder)
    {
        List<IOrderLine> supplierOrderLines = supplierOrder.Lines.Cast<IOrderLine>().ToList();

        var negoSudDetails = _configuration.GetSection("NegoSudDetails");
        var negoSudAddress = new List<string>
        {
            negoSudDetails.GetValue<string>("Address"),
            negoSudDetails.GetValue<string>("City"),
            negoSudDetails.GetValue<string>("ZipCode"),
            negoSudDetails.GetValue<string>("Country"),
        };

        string negosudURL = negoSudDetails.GetValue<string>("SiteWeb");

        var supplierDetails = new List<string>
        {
            supplierOrder.Supplier.Address.AddressLine1,
            supplierOrder.Supplier.Address.AddressLine2,
            supplierOrder.Supplier.Address.City.Name,
            supplierOrder.Supplier.Address.City.ZipCode.ToString(),
            supplierOrder.Supplier.Address.City.Country.Name
        };
        
        var terms = new List<string>
        {
            "Termes et conditions",
            string.Empty,
            "Si vous avez la moindre question concernant cette commande, merci de revenir vers nous.",
            string.Empty,
            "Merci pour votre service," ,
            string.Empty,
            "Cordialment,",
            string.Empty,
            "L'équipe de NegoSud"
        };
        
        var pdfPath =
            new GeneratePdf(supplierOrder.Reference, negoSudAddress, supplierOrderLines, supplierDetails, _vatService, terms, negosudURL)
                .SavePurchaseOrderLocally();
        var isEmailSent = await _emailService.SendPurchaseOrderEmailAsync(supplierOrder.Supplier.Email, $"Bon de commande",
            pdfPath, _configuration);


        if (!string.IsNullOrEmpty(pdfPath) && isEmailSent)
        {
            try
            {
            System.IO.File.Delete(pdfPath);
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Information, ex.ToString());
            }
        }
    }

    //</inheritdoc>  
    public async Task<SupplierOrder?> UpdateSupplierOrderAsync(SupplierOrder supplierOrder)
    {
        try
        {
            // get the current supplierOrder from db
            SupplierOrder? dbSupplierOrder = await this.GetSupplierOrderAsync(supplierOrder.Id);

            if (dbSupplierOrder != null)
            {
                dbSupplierOrder.Reference = supplierOrder.Reference;
                dbSupplierOrder.Description = supplierOrder.Description;
                dbSupplierOrder.DateOrder = supplierOrder.DateOrder;
                dbSupplierOrder.DateDelivery = supplierOrder.DateDelivery;
                dbSupplierOrder.DeliveryStatus= supplierOrder.DeliveryStatus;


                if (supplierOrder.Supplier != null)
                {
                    Supplier? supplier =
                        await _supplierService.GetSupplierAsync(supplierOrder.Supplier.Id, includeRelations: false);
                    // If we found a supplier in the database
                    if (supplier != null)
                    {
                        dbSupplierOrder.Supplier = supplier;
                    }
                }


                if (supplierOrder.Lines != null && dbSupplierOrder.Lines != null)
                {
                    ICollection<SupplierOrderLine>? dbLines = dbSupplierOrder.Lines.ToList();

                    foreach (SupplierOrderLine Line in supplierOrder.Lines)
                    {
                        if (Line.BottleId != null)
                        {
                            Bottle? bottle =
                                await _bottleService.GetBottleAsync((int) Line.BottleId, includeRelations: false);
                            if (bottle != null)
                            {
                                Line.Bottle = bottle;
                            }
                        }

                        //if the Line already exists
                        SupplierOrderLine? existingLine = dbLines.FirstOrDefault(l => l.Id == Line.Id);

                        if (existingLine != null)
                        {
                            //update the existing Line
                            existingLine.Bottle = Line.Bottle;
                            existingLine.Quantity = Line.Quantity;
                            _context.Entry(existingLine).State = EntityState.Modified;
                            dbLines.Remove(existingLine);
                        }
                        else
                        {
                            // otherwise, add the new Line to the current supplierOrder
                            dbSupplierOrder.Lines.Add(Line);
                        }
                    }

                    foreach (SupplierOrderLine LineToDelete in dbLines)
                    {
                        dbSupplierOrder.Lines.Remove(LineToDelete);
                    }
                }

                _context.Entry(dbSupplierOrder).State = EntityState.Modified;

                await _context.SaveChangesAsync();

                return dbSupplierOrder;
            }
        }
        catch (Exception ex)
        {
            _logger.Log(LogLevel.Information, ex.ToString());
        }

        return null;
    }

    //</inheritdoc>  
    public async Task<bool?> DeleteSupplierOrderAsync(int id)
    {
        try
        {
            //var dbSupplierOrder = await _context.SupplierOrders.FindAsync(id);
            var dbSupplierOrder = await this.GetSupplierOrderAsync(id, true);

            if (dbSupplierOrder == null)
            {
                return false;
            }

            if (dbSupplierOrder.Lines != null)
            {
                _context.RemoveRange(dbSupplierOrder.Lines);
            }

            _context.SupplierOrders.Remove(dbSupplierOrder);
            await _context.SaveChangesAsync();

            return true;
        }
        catch (Exception ex)
        {
            _logger.Log(LogLevel.Information, ex.ToString());
        }

        return null;
    }
}