using Domain.Entities;
using Domain.FluentValidations.HBSIS.Padawan.Produtos.Domain;
using FluentValidation;
using System.Collections.Generic;
using System.Linq;

namespace Domain.FluentValidations
{
    class DeliveryManValidation : AbstractValidator<DeliveryMan>
    {
        public HashSet<Error> CustomValidate(DeliveryMan deliveryMan)
        {
            return Validate(deliveryMan).Errors.Select(f => new Error(f.PropertyName, f.ErrorMessage)).ToHashSet();
        }

        public DeliveryManValidation()
        {
            RuleFor(d => d.Name)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty().WithMessage("Nome deve ser informado").OverridePropertyName("Nome")
                .NotNull().WithMessage("Nome deve ser informado").OverridePropertyName("Nome")
                .Length(2, 100).WithMessage("Nome deve conter entre 2 a 100 caracteres").OverridePropertyName("Nome");

            RuleFor(d => d.Salary)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty().WithMessage("Salario deve ser informado").OverridePropertyName("Salario")
                .GreaterThan(0).WithMessage("Salario deve ser maior que 0").OverridePropertyName("Salario");

            RuleFor(d => d.PIS)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotNull().WithMessage("PIS deve ser informado").OverridePropertyName("PIS")
                .NotEmpty().WithMessage("PIS deve ser informado").OverridePropertyName("PIS")
                .Length(14).WithMessage("PIS invalido").OverridePropertyName("PIS");
        }
    }
}
