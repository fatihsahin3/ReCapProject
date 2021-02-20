using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class BrandValidator : AbstractValidator<Brand>
    {
        public BrandValidator() 
        {
            RuleFor(b => b.BrandId).NotEmpty();
            RuleFor(b => b.BrandId).GreaterThan(0);
            RuleFor(b => b.BrandName).NotEmpty();
            RuleFor(b => b.BrandName).MinimumLength(2);
        }
    }
}