namespace NegoSudApi.Services.Interfaces;

public interface IEmailService
{
    /// <summary>
    /// Sends an email message with a PDF attachment to the specified recipient email address.
    /// </summary>
    /// <param name="recipient">The email address of the recipient.</param>
    /// <param name="emailSubject">The subject of the email message.</param>
    /// <param name="filePathToAttach">The path to the PDF file to attach to the email.</param>
    /// <param name="configuration">Provides access to the application's configuration settings.</param>
    /// <returns>Returns true if the email is sent successfully; otherwise, false.</returns>
    public Task<bool> SendPurchaseOrderEmailAsync(string recipient, string emailSubject, string filePathToAttach, IConfiguration configuration);
}