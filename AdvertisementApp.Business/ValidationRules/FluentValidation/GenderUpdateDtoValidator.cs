using AdvertisementApp.Dtos.GenderDtos;
using FluentValidation;

namespace AdvertisementApp.Business.ValidationRules.FluentValidation
{
    public class GenderUpdateDtoValidator : AbstractValidator<GenderUpdateDto>
    {
        public GenderUpdateDtoValidator() 
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.Definition).NotEmpty();
        }
    }
}
