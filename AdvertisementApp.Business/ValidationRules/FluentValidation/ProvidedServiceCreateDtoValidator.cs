using FluentValidation;
using AdvertisementApp.Dtos.ProvidedServiceDtos;

namespace AdvertisementApp.Business.ValidationRules.FluentValidation
{
    public class ProvidedServiceCreateDtoValidator : AbstractValidator<ProvidedServiceCreateDto>
    {
        public ProvidedServiceCreateDtoValidator()
        {
            RuleFor(x => x.Title).NotEmpty();
            RuleFor(x => x.Description).NotEmpty();
            RuleFor(x => x.ImagePath).NotEmpty();
        }
    }
}
