using Microsoft.Extensions.Options;
using moneyucab_portalweb_back.Email;
using moneyucab_portalweb_back.Models;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace moneyucab_portalweb_back.Services
{
    public class SendGridEmailSender : IEmailSender
    {
        private readonly ApplicationSettings _applicationSettings;
        public SendGridEmailSender(IOptions<ApplicationSettings> applicationSettings)
        {
            _applicationSettings = applicationSettings.Value;
        }

        public async Task<SendEmailResponse> SendEmailAsync(string userEmail, string emailSubject, string message)
        {
            var apiKey = _applicationSettings.SendGridKey;
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress("moneyucab@gmail.com", "MoneyUCAB");
            var subject = emailSubject;
            var to = new EmailAddress(userEmail, "Example User");
            var plainTextContent = message;
            var htmlContent = message;
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var response = await client.SendEmailAsync(msg);

            return new SendEmailResponse();
        }

    }
}
