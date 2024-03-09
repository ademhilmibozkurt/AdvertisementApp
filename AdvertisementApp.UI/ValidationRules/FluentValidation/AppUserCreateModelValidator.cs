using AdvertisementApp.UI.Models;
using FluentValidation;

namespace AdvertisementApp.UI.ValidationRules.FluentValidation
{
    public class AppUserCreateModelValidator : AbstractValidator<AppUserCreateModel>
    {
        public AppUserCreateModelValidator() 
        {
            RuleFor(x => x.FirstName).MinimumLength(2).WithMessage("Ad en az 2 karakter olmalı!");
            RuleFor(x => x.FirstName).NotEmpty().WithMessage("Ad boş geçilemez!");

            RuleFor(x => x.LastName).MinimumLength(2).WithMessage("Soyad en az 2 karakter olmalı!");
            RuleFor(x => x.LastName).NotEmpty().WithMessage("Soyad boş geçilemez!");

            RuleFor(x => x.Email).NotEmpty().WithMessage("Email boş geçilemez!"); 
            RuleFor(x => x.PhoneNumber).NotEmpty().WithMessage("Telefon boş geçilemez!");

            RuleFor(x => new { x.UserName, x.FirstName}).Must(x => 
                    CanNotFirstName(x.UserName, x.FirstName)).WithMessage("Kullanıcı adı, isim içeremez!").When(x =>
                    x.UserName != null && x.FirstName != null);
            RuleFor(x => x.UserName).MinimumLength(5).WithMessage("Kullanıcı adı en az 5 karakter olmalı!");
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Kullanıcı adı boş geçilemez!");

            RuleFor(x => x.Password).MinimumLength(6).WithMessage("Şifre en az 6 karakter olmalı!");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Şifre boş geçilemez!");
            RuleFor(x => x.ConfirmedPassword).NotEmpty().WithMessage("Şifre tekrar boş geçilemez!");
            RuleFor(x => x.Password).Equal(x => x.ConfirmedPassword).WithMessage("Şifreler eşleşmiyor!");
        }

        private bool CanNotFirstName(string userName, string firstName)
        {
            return !userName.Contains(firstName);
        }
    }
}
