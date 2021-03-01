using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class ProcessValidator : AbstractValidator<Process>
    {
        public ProcessValidator()
        {
            RuleFor(p => p.BorrowDate).NotEmpty();
        }
    }
}
