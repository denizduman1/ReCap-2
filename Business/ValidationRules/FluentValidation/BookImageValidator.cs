using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class BookImageValidator : AbstractValidator<BookImage>
    {
        public BookImageValidator()
        {
            RuleFor(b => b.BookId).NotEmpty();
        }
    }
}
