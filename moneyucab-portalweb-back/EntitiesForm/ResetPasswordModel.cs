using System.ComponentModel.DataAnnotations;

namespace moneyucab_portalweb_back.EntitiesForm
{
    public class ResetPasswordModel
    {
        [Required]
        public string UserID { get; set; }
        [Required]
        public string ResetPasswordToken { get; set; }
        [Required]
        public string NewPassword { get; set; }
    }
}
