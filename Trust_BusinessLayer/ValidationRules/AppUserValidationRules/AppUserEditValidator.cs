using FluentValidation;
using TrustBank_DTOLayer.DTOs.AppUserDTOs;

namespace TrustBank_BusinessLayer.ValidationRules.AppUserValidationRules
{
    public class AppUserEditValidator : AbstractValidator<AppUserEditDto>
    {
        public AppUserEditValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Lütfen İsim giriniz");
            RuleFor(x => x.Surname).NotEmpty().WithMessage("Lütfen Soyisim giriniz");
            RuleFor(x => x.Name).MaximumLength(50).WithMessage("İsim 50 karakterden daha az olmalıdır");
            RuleFor(x => x.Name).MinimumLength(2).WithMessage("İsim 2 karakterden daha fazla olmalıdır");
            RuleFor(x => x.Surname).MaximumLength(50).WithMessage("Soyisim 50 karakterden daha az olmalıdır");
            RuleFor(x => x.Surname).MinimumLength(2).WithMessage("Soyisim 2 karakterden daha fazla olmalıdır");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Lütfen mail adresi giriniz");
            RuleFor(x => x.Email).EmailAddress().WithMessage("Lütfen geçerli bir mail adresi giriniz");
            RuleFor(x => x.ConfirmPassword).Equal(y => y.Password).WithMessage("Şifreler eşleşmiyor!");
            // district, city, imageurl, phonenumber, password icin henuz validasyon yapılmadı!
        }
    }
}
