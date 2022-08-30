using FluentValidation;
using Graph.API.Schemas;

namespace Graph.API.Validators;

public class CustomerValidator : AbstractValidator<AddCustomerInput>
{
    public CustomerValidator()
    {
        RuleFor(x => x.Forename).NotEmpty().WithMessage("Forename cannot be empty.");
        RuleFor(x => x.Surname).NotEmpty().WithMessage("Surname cannot be empty.");
    }
}