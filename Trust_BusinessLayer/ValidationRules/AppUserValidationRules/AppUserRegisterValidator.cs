using FluentValidation;
using TrustBank_DTOLayer.DTOs.AppUserDTOs;

namespace TrustBank_BusinessLayer.ValidationRules.AppUserValidationRules
{
    public class AppUserRegisterValidator : AbstractValidator<AppUserRegisterDto>
    {
        public AppUserRegisterValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Lütfen bir isim giriniz");
            RuleFor(x => x.Surname).NotEmpty().WithMessage("Lütfen soyisim giriniz");
            RuleFor(x => x.Username).NotEmpty().WithMessage("Lütfen kullanıcıadı giriniz");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Lütfen bir şifre giriniz");
            RuleFor(x => x.ConfirmPassword).Equal(y => y.Password).WithMessage("Şifreler eşleşmiyor!");
            RuleFor(x => x.Email).EmailAddress().WithMessage("Lütfen geçerli bir mail adresi giriniz");
            RuleFor(x => x.Name).MinimumLength(2).WithMessage("İsim 2 karakterden daha uzun olmalıdır");
            RuleFor(x => x.Name).MaximumLength(50).WithMessage("İsim 50 karakterden daha uzun olamaz");
            RuleFor(x => x.Surname).MinimumLength(2).WithMessage("Soyisim 2 karakterden daha az olamaz");
            RuleFor(x => x.Surname).MaximumLength(50).WithMessage("Soyisim 50 karakterden daha fazla olamaz");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Lütfen bir mail adresi giriniz");
        }
    }
}
