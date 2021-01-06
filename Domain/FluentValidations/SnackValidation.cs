using Domain.Entities;
using Domain.FluentValidations.HBSIS.Padawan.Produtos.Domain;
using FluentValidation;
using System.Collections.Generic;
using System.Linq;

namespace Domain.FluentValidations
{
    class SnackValidation : AbstractValidator<Snack>
    {
        public HashSet<Error> CustomValidate(Snack snack)
        {
            return Validate(snack).Errors.Select(f => new Error(f.PropertyName, f.ErrorMessage)).ToHashSet();
        }

        public SnackValidation()
        {
            RuleFor(d => d.Name)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty().WithMessage("Nome deve ser informado").OverridePropertyName("Nome")
                .NotNull().WithMessage("Nome deve ser informado").OverridePropertyName("Nome")
                .Length(2, 100).WithMessage("Nome deve conter entre 2 a 100 caracteres").OverridePropertyName("Nome");

            RuleFor(d => d.Description)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty().WithMessage("Descrição deve ser informado").OverridePropertyName("Descrição")
                .NotNull().WithMessage("Descrição deve ser informado").OverridePropertyName("Descrição")
                .Length(2, 100).WithMessage("Descrição deve conter entre 2 a 100 caracteres").OverridePropertyName("Descrição");

            RuleFor(d => d.Price)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty().WithMessage("Preço deve ser informado").OverridePropertyName("Preço")
                .GreaterThan(0).WithMessage("Preço deve ser maior que 0").OverridePropertyName("Preço");
        }
    }
}
