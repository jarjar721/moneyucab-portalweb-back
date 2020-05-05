using Microsoft.Extensions.Options;
using moneyucab_portalweb_back.Email;
using moneyucab_portalweb_back.Models;
using Newtonsoft.Json;
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

        private class EmailData
        {
            [JsonProperty("name")]
            public string Name { get; set; }
            [JsonProperty("URL")]
            public string URL { get; set; }
        }

        public async Task<SendEmailResponse> SendEmailAsync(string templateID, string userEmail, string userName, string emailSubject, string url)
        {
            var apiKey = _applicationSettings.SendGridKey;

            var client = new SendGridClient(apiKey);
            var sendGridMessage = new SendGridMessage();

            sendGridMessage.SetFrom("moneyucab@gmail.com", "MoneyUCAB");
            sendGridMessage.AddTo(userEmail, userName);
            sendGridMessage.SetSubject(emailSubject);
            sendGridMessage.SetTemplateId(templateID);
            sendGridMessage.SetTemplateData(new EmailData
            {
                Name = userName,
                URL = url
            });

            //var from = new EmailAddress("moneyucab@gmail.com", "MoneyUCAB");
            //var subject = emailSubject;
            //var to = new EmailAddress(userEmail, "Example User");

            //var plainTextContent = url;
            //var htmlContent = url;
            //var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            //var response = await client.SendEmailAsync(msg);
            var response = await client.SendEmailAsync(sendGridMessage);

            return new SendEmailResponse();
        }

    }
}
