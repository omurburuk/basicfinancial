using BasicFinancial.DTO;
using FluentValidation;

namespace BasicFinancial.Validators
{
    public class SaveAccountResourceValidator : AbstractValidator<SaveAccountDTO>
    {
        public SaveAccountResourceValidator()
        {
            RuleFor(m => m.Name)
                .NotEmpty()
                .MaximumLength(50);

            RuleFor(m => m.CustomerId)
                .NotEmpty()
                .WithMessage("'Customer Id' must not be 0.");
        }
    }
}
