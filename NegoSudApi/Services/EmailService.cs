using System.Net;
using System.Net.Mail;
using NegoSudApi.Data;

namespace NegoSudApi.Services.Interfaces;

public class EmailService : IEmailService
{
    private readonly ILogger<EmailService> _logger;

    public EmailService(ILogger<EmailService> logger)
    {
        _logger = logger;
    }

    public Task<bool> SendEmail(ContactForm contactForm, IConfiguration configuration)
    {
        var emailSettings = configuration.GetSection("EmailSettings");
        var emailUsername = emailSettings.GetValue<string>("Username");
        var emailPassword = emailSettings.GetValue<string>("Password");
        var emailNegoSud = emailSettings.GetValue<string>("EmailAddress");

        var message = new MailMessage(emailNegoSud, emailNegoSud)
        {
            Subject = contactForm.Subject,
            Body = contactForm.Message,
            IsBodyHtml = true
        };

        var client = new SmtpClient("smtp.gmail.com", 587)
        {
            Credentials = new NetworkCredential(emailUsername, emailPassword),
            EnableSsl = true
        };

        try
        {
            client.Send(message);
            return Task.FromResult(true);
        }
        catch (Exception ex)
        {
            _logger.Log(LogLevel.Warning, "Error sending email: {ExceptionMessage}", ex.Message);
            return Task.FromResult(false);
        }
    }

    /// <inheritdoc />
    public Task<bool> SendPurchaseOrderEmailAsync(string recipient, string emailSubject, string filePathToAttach, IConfiguration configuration)
    {
        string htmlBody = "<html><body><p>Bonjour,</p>" +
                          "<p>Nous souhaiterions vous commande les références ci jointes,</p>" +
                          "<p>Bien à vous,</p></body></html>";

        var emailSettings = configuration.GetSection("EmailSettings");
        var emailUsername = emailSettings.GetValue<string>("Username");
        var emailPassword = emailSettings.GetValue<string>("Password");
        var emailSender = emailSettings.GetValue<string>("EmailAddress");

        var message = new MailMessage(emailSender, recipient)
        {
            Subject = emailSubject,
            Body = htmlBody,
            IsBodyHtml = true
        };

        // Add the PDF file as an attachment
        var attachment = new Attachment(filePathToAttach);
        message.Attachments.Add(attachment);

        var client = new SmtpClient("smtp.gmail.com", 587)
        {
            Credentials = new NetworkCredential(emailUsername, emailPassword),
            EnableSsl = true
        };

        try
        {
            client.Send(message);
            return Task.FromResult(true);
        }
        catch (Exception ex)
        {
            _logger.Log(LogLevel.Warning, "Error sending email: {ExceptionMessage}", ex.Message);
            return Task.FromResult(false);
        }
    }
}