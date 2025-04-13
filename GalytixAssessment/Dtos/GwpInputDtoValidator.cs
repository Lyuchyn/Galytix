using FluentValidation;

namespace GalytixAssessment.Dtos
{
    public class GwpInputDtoValidator : AbstractValidator<GwpInputDto>
    {
        public GwpInputDtoValidator()
        {
            RuleFor(x => x.Country)
                .NotEmpty().WithMessage("Country must not be empty.");

            RuleFor(x => x.Lob)
                .NotEmpty().WithMessage("Lob must not be an empty collection.");
        }
    }
}
