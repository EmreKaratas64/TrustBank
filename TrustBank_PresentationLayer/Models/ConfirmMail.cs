
using System.ComponentModel.DataAnnotations;

namespace TrustBank_PresentationLayer.Models
{
    public class ConfirmMail
    {
        [Required(ErrorMessage = "Mail adresi boş olamaz")]
        [EmailAddress(ErrorMessage = "Mail adresi geçersiz")]
        public string Mail { get; set; }

        public string ConfirmCode { get; set; }
    }
}
