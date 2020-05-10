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

        // Model Class para enviar el Json que contiene la info del mesaje.
        // Podría ser creada en un archivo aparte
        private class EmailData
        {
            [JsonProperty("name")]
            public string Name { get; set; }
            [JsonProperty("URL")]
            public string URL { get; set; }
        }


        public async Task<SendEmailResponse> SendEmailAsync(string templateID, string userEmail, string userName, string emailSubject, string url)
        {
            // Busco código de la API de SendGrid
            var apiKey = _applicationSettings.SendGridKey;

            // Se crea el cliente
            var client = new SendGridClient(apiKey);

            // Se crea un nuevo mensaje de SendGrid
            var sendGridMessage = new SendGridMessage();

            // Se prepara el mensaje con la info necesaria
            sendGridMessage.SetFrom("moneyucab@gmail.com", "MoneyUCAB");
            sendGridMessage.AddTo(userEmail, userName);
            sendGridMessage.SetSubject(emailSubject);
            sendGridMessage.SetTemplateId(templateID);
            sendGridMessage.SetTemplateData(new EmailData
            {
                Name = userName,
                URL = url
            });

            // Se envía el mensaje
            var response = await client.SendEmailAsync(sendGridMessage);

            return new SendEmailResponse();
        }

    }
}
