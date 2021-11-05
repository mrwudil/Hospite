using Microsoft.Extensions.Options;
using MimeKit;
using System.IO;
using MailKit.Net.Smtp;
using System.Threading.Tasks;
using MailKit.Security;

namespace Hospite.Data.Repository
{
    public class MailService : IMailService
    {
        private readonly MailConfig _options;

        public MailService(IOptions<MailConfig> options)
        {
            _options = options.Value;
        }
        public async Task SendMailAsync(MailRequest mailRequest)
        {
            //string FilePath = Directory.GetCurrentDirectory() + "\\View\\Email\\Mail.html";
            //StreamReader str = new StreamReader(FilePath);
            //string MailText = str.ReadToEnd();
            //str.Close();

            //MailText = MailText.Replace("[UserName]", mailRequest.Name)
            //                    .Replace("[Message", mailRequest.RecipientMail);

            var MailText =  mailRequest.Body;
            var email = new MimeMessage();
            email.Sender = MailboxAddress.Parse(_options.Mail);
            email.To.Add(MailboxAddress.Parse(mailRequest.RecipientMail));
            email.Subject = mailRequest.Subject;
            var builder = new BodyBuilder();
            builder.HtmlBody = MailText;
            email.Body = builder.ToMessageBody();
            using var smtp = new SmtpClient();
            smtp.CheckCertificateRevocation = false;

            smtp.Connect(_options.Host, _options.Port, SecureSocketOptions.SslOnConnect);
            smtp.Authenticate(_options.Mail, _options.Password);
            await smtp.SendAsync(email);
            smtp.Disconnect(true);
        }
    }
}
