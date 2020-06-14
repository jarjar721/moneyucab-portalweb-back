using System.ComponentModel.DataAnnotations;

namespace moneyucab_portalweb_back.Models.FormModels
{
    public class ForgotPasswordModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
