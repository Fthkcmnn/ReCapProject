using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete;

namespace Business.ValidationRules.FluentValidation
{
    public class CarValidator : AbstractValidator<Car>
    {
        public CarValidator()
        {
            RuleFor(c => c.Description).MinimumLength(2);
            RuleFor(c => c.Description).NotEmpty();
            RuleFor(c => c.ColorId).NotEmpty();
            //RuleFor(c => c.DailyPrice).GreaterThanOrEqualTo(10).When(p => p.ColorId == 1);
            RuleFor(c => c.Description).Must(startWithA).WithMessage("Açıklama A harfi ile başlamalı");
        }

        private bool startWithA(string arg)
        {
            return arg.StartsWith("A");
        }
    }
}