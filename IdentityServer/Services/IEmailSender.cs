using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer.Services
{
    public interface IEmailSender
    {
        //Task SendEmail(string email, string subject, string message, string toUsername);
        Task SendSmtpEmail(string email, string subject, string message, string toUsername);        
    }
}
