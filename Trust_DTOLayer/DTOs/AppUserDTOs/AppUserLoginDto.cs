using System.ComponentModel.DataAnnotations;

namespace TrustBank_DTOLayer.DTOs.AppUserDTOs
{
    public class AppUserLoginDto
    {
        [Required(ErrorMessage="Lütfen kullanıcı adı giriniz")]
        public string UserName { get; set; }
        [Required(ErrorMessage ="Lütfen şifre giriniz")]
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}
