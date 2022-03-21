using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TemplateWebApi2.Application.Commands;

namespace TemplateWebApi2.Application.Validators
{
    public class NewSubscriptionValidator : AbstractValidator<NewSubscriptionCommand>
    {
        public NewSubscriptionValidator()
        {
            RuleFor(v => v.ProductId)
                .NotEmpty();

            RuleFor(v => v.CustomerId)
                .NotEmpty();
        }
    }
}
