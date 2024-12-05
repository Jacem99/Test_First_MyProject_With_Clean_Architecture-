
using MailKit.Net.Smtp;
using MimeKit;
using MyProject.Data.Helper;
using MyProject.Service.IServices;
namespace MyProject.Service.Services
{
    public class EmailService : IEmailService
    {
        private readonly EmailSettings _emailsettings;

        public EmailService(EmailSettings emailsettings)
        {
            _emailsettings = emailsettings;
        }

        public async Task<string> SendEmailAsync(string subject, string email, string Message)
        {
            try
            {
                using (var client = new SmtpClient())
                {
                    await client.ConnectAsync(_emailsettings.Host, _emailsettings.Port, _emailsettings.UseSsl);
                    client.Authenticate(_emailsettings.AuthenticationMail, _emailsettings.AuthenticationAppPassword);

                    var bodyBuilder = new BodyBuilder
                    {
                        HtmlBody = $"{Message}",
                        TextBody = "wellcome",
                    };

                    var message = new MimeMessage
                    {
                        Body = bodyBuilder.ToMessageBody()
                    };
                    message.From.Add(new MailboxAddress(_emailsettings.NameEnterPrice, _emailsettings.From));
                    message.To.Add(new MailboxAddress(email, email));
                    message.Subject = subject;
                    await client.SendAsync(message);
                    await client.DisconnectAsync(true);
                }
                return "Success";
            }
            catch (Exception ex)
            {
                return "Faild";
            }
        }
    }
}