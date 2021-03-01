using Entities.Concrete;
using FluentValidation;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class AuthorValidator : AbstractValidator<Author>
    {
        public AuthorValidator()
        {
            RuleFor(a => a.FirstName).NotEmpty();
            RuleFor(a => a.FirstName).MinimumLength(3);
            RuleFor(a => a.LastName).NotEmpty();
            RuleFor(a => a.LastName).MinimumLength(3);
        }
    }
}
