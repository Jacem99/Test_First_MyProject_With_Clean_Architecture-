namespace MyProject.Service.IServices
{
    public interface IEmailService
    {
        Task<string> SendEmailAsync(string subject, string email, string Message);
    }
}
