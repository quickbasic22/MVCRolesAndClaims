﻿using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Options;
using MimeKit.Text;
using MimeKit;
using MailKit.Net.Smtp;

namespace MVCRolesAndClaims.Areas.Identity.Data
{
    public class MailKitEmailSender : IEmailSender
    {
        private readonly IOptions<MailKitEmailSenderOptions> options;


        public MailKitEmailSender(IOptions<MailKitEmailSenderOptions> options)
        {
            this.Options = options.Value;
            this.options = options;
        }

        public MailKitEmailSenderOptions Options { get; set; }

        public Task SendEmailAsync(string email, string subject, string message)
        {
            return Execute(email, subject, message);
        }

        public Task Execute(string to, string subject, string message)
        {
            // create messageOptions.Host_SecureSocketOptions = 
            
            var email = new MimeMessage();
            email.Sender = MailboxAddress.Parse(Options.Sender_EMail);
            if (!string.IsNullOrEmpty(Options.Sender_Name))
                email.Sender.Name = Options.Sender_Name;
            email.From.Add(email.Sender);
            email.To.Add(MailboxAddress.Parse(to));
            email.Subject = subject;
            email.Body = new TextPart(TextFormat.Html) { Text = message };
            

            // send email
            using (var smtp = new SmtpClient())
            {
                smtp.Connect(Options.Host_Address, Options.Host_Port, Options.Host_SecureSocketOptions);
                smtp.Authenticate(Options.Host_Username, Options.Host_Password);
                smtp.Send(email);
                smtp.Disconnect(true);
            }

            return Task.FromResult(true);
        }
    }
}
