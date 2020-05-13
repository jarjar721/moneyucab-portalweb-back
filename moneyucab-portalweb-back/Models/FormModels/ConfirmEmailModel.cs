using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace moneyucab_portalweb_back.Models.FormModels
{
    public class ConfirmEmailModel
    {
        public string UserID { get; set; }
        public string ConfirmationToken { get; set; }
    }
}
