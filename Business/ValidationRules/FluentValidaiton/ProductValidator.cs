using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete;

namespace Business.ValidationRules.FluentValidation
{
    public class ProductValidator : AbstractValidator<Car>
    {
        public ProductValidator()
        {
            RuleFor(p => p.Description).MinimumLength(2);
            RuleFor(p => p.Description).NotEmpty();
            RuleFor(p => p.ColorId).NotEmpty();
            RuleFor(p => p.DailyPrice).GreaterThan(0);
            RuleFor(p => p.DailyPrice).GreaterThanOrEqualTo(10).When(p => p.ColorId == 1);
            RuleFor(p => p.Description).Must(startWithA).WithMessage("Açıklama A harfi ile başlamalı");
        }

        private bool startWithA(string arg)
        {
            return arg.StartsWith("A");
        }
    }
}