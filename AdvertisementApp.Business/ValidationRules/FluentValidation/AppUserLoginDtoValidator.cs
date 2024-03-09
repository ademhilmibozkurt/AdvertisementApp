using AdvertisementApp.Dtos.AppUserDtos;
using FluentValidation;

namespace AdvertisementApp.Business.ValidationRules.FluentValidation
{
    public class AppUserLoginDtoValidator : AbstractValidator<AppUserLoginDto>
    {
        public AppUserLoginDtoValidator() 
        {
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Kullanıcı adı girilmedi!");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Şifre girilmedi!");
        }
    }
}
