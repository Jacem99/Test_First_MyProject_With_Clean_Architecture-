
using MailKit.Net.Smtp;
using MimeKit;
using MyProject.Service.IServices;
namespace MyProject.Service.Services
{
    public class EmailService : IEmailService
    {

        public async Task<string> SendEmailAsync(string subject, string email, string Message)
        {
            try
            {
                using (var client = new SmtpClient())
                {
                    await client.ConnectAsync("smtp.gmail.com", 465, true);
                    client.Authenticate("mustafakhalil1199@gmail.com", "wmkqygsyggecrpnd");

                    var bodyBuilder = new BodyBuilder
                    {
                        HtmlBody = $"{Message}",
                        TextBody = "wellcome",
                    };

                    var message = new MimeMessage
                    {
                        Body = bodyBuilder.ToMessageBody()
                    };
                    message.From.Add(new MailboxAddress("UniversityTeam", "mustafakhalil1199@gmail.com"));
                    message.To.Add(new MailboxAddress("MustafaKhalil", email));
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