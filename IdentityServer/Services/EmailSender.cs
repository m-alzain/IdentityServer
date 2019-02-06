using Microsoft.Extensions.Options;
using IdentityServer.Models;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;
using System;

namespace IdentityServer.Services
{
    public class EmailSender : IEmailSender
    {
        private readonly IOptions<EmailSettings> _optionsEmailSettings;
        private readonly IOptions<SmtpEmailSettings> _optionsSmtpEmailSettings;        
        private readonly SmtpClient _smtpClient;

        public EmailSender(IOptions<EmailSettings> optionsEmailSettings, IOptions<SmtpEmailSettings> optionsSmtpEmailSettings, SmtpClient smtpClient)
        {
            _optionsEmailSettings = optionsEmailSettings;
            _optionsSmtpEmailSettings = optionsSmtpEmailSettings;           
            _smtpClient = smtpClient;
        }


        //public async Task SendEmail(string email, string subject, string message, string toUsername)
        //{
        //    var client = new SendGridClient(_optionsEmailSettings.Value.SendGridApiKey);
        //    var msg = new SendGridMessage();
        //    msg.SetFrom(new EmailAddress(_optionsEmailSettings.Value.SenderEmailAddress, "damienbod"));
        //    msg.AddTo(new EmailAddress(email, toUsername));
        //    msg.SetSubject(subject);
        //    msg.AddContent(MimeType.Text, message);
        //    //msg.AddContent(MimeType.Html, message);

        //    msg.SetReplyTo(new EmailAddress(_optionsEmailSettings.Value.SenderEmailAddress, "damienbod"));

        //    var response = await client.SendEmailAsync(msg);
        //}

        public async Task SendSmtpEmail(string email, string subject, string message, string toUsername)
        {
            MailMessage mail = new MailMessage
            {
                From = new MailAddress(_optionsSmtpEmailSettings.Value.Username)
            };

            //recipient address
            mail.To.Add(new MailAddress(email,toUsername));

            //Formatted mail body
            mail.IsBodyHtml = true;
            mail.Subject = subject;           
            mail.Body = message;

            await _smtpClient.SendMailAsync(mail);           

        }      
       
    }
}
