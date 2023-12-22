using BasicFinancial.DTO;
using FluentValidation;

namespace BasicFinancial.Validators
{
    public class SaveCustomerResourceValidator : AbstractValidator<SaveCustomerDTO>
    {
        public SaveCustomerResourceValidator()
        {
            RuleFor(a => a.FirstName)
              .NotEmpty()
              .MaximumLength(50);

            RuleFor(a => a.LastName)
              .NotEmpty()
              .MaximumLength(50);

            RuleFor(a => a.IdentityNumber)
              .NotEmpty()
              .Length(11);
        }
    }
}
