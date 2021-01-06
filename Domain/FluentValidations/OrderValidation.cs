using Domain.Entities;
using Domain.FluentValidations.HBSIS.Padawan.Produtos.Domain;
using FluentValidation;
using System.Collections.Generic;
using System.Linq;

namespace Domain.FluentValidations
{
    class OrderValidation : AbstractValidator<Order>
    {

        public HashSet<Error> CustomValidate(Order order)
        {
            return Validate(order).Errors.Select(f => new Error(f.PropertyName, f.ErrorMessage)).ToHashSet();
        }

        public OrderValidation()
        {
            RuleFor(d => d.UserId)
                .GreaterThan(0).WithMessage("Usuario invalido").OverridePropertyName("Usuario");
        }
    }
}
