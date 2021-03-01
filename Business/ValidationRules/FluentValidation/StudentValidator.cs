using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class StudentValidator : AbstractValidator<Student>
    {
        public StudentValidator()
        {
            RuleFor(s => s.FirstName).NotEmpty();
            RuleFor(s => s.FirstName).MinimumLength(3);
            RuleFor(s => s.LastName).NotEmpty();
            RuleFor(s => s.LastName).MinimumLength(2);
            RuleFor(s => s.Gender).NotEmpty();
            RuleFor(s => s.Department).NotEmpty();
            RuleFor(s => s.Birthday).NotEmpty();
        }
    }
}
