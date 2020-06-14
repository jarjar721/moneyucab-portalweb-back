namespace moneyucab_portalweb_back.Models.FormModels
{
    public class ConfirmEmailModel
    {
        public string UserID { get; set; }
        public string ConfirmationToken { get; set; }
    }
}
