using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NegoSudApi.Data;
using NegoSudApi.Services.Interfaces;

namespace NegoSudApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class Emailcontroller : ControllerBase
{
    private readonly IEmailService _emailService;
    private readonly IConfiguration _configuration;

    public Emailcontroller(IEmailService emailService, IConfiguration configuration)
    {
        _emailService = emailService;
        _configuration = configuration;
    }

    [Authorize(Policy = RolePermissions.CandSendEmail)]
    [HttpPost("SendEmail")]
    public async Task<ActionResult> SendMailAsync(ContactForm contactForm)
    {
        if (await _emailService.SendEmail(contactForm, _configuration))
        {
            return StatusCode(StatusCodes.Status200OK, "Email sent");
        }

        return StatusCode(StatusCodes.Status404NotFound);
    }
}