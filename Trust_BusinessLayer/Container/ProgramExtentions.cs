using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using TrustBank_BusinessLayer.ValidationRules.AppUserValidationRules;
using TrustBank_DTOLayer.DTOs.AppUserDTOs;

namespace TrustBank_BusinessLayer.Container
{
    public static class ProgramExtentions
    {

        public static void CustomValidator(this IServiceCollection services)
        {
            services.AddTransient<IValidator<AppUserRegisterDto>, AppUserRegisterValidator>();
            services.AddTransient<IValidator<AppUserEditDto>, AppUserEditValidator>();
        }
    }
}
