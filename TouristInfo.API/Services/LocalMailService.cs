namespace TouristInfo.API.Services;

public class LocalMailService(IConfiguration configuration) : IMailService
{
    private string _mailTo = configuration["mailSettings:mailToAddress"]
            ?? throw new ArgumentNullException("mailSettings:mailToAddress");
    private string _mailFrom = configuration["mailSettings:mailFromAddress"]
            ?? throw new ArgumentNullException("mailSettings:mailFromAddress");

    public void Send(string subject, string message)
    {
        // send mail - output to console window
        Console.WriteLine($"Mail from {_mailFrom} to {_mailTo}, with {nameof(LocalMailService)}.");
        Console.WriteLine($"Subject: {subject}");
        Console.WriteLine($"Message: {message}");
    }
}
