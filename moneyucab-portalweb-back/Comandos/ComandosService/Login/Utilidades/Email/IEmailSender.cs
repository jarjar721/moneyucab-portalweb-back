using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace moneyucab_portalweb_back.Email
{
    public interface IEmailSender
    {
        // Send email with given information
        //Task<SendEmailResponse> SendEmailAsync(string templateID, string userEmail, string userName, string emailSubject, string message);
        Task<SendEmailResponse> SendEmailAsync(SendEmailDetails emailDetails);

    }
}
