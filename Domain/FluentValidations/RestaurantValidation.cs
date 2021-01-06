using Domain.Entities;
using Domain.FluentValidations.HBSIS.Padawan.Produtos.Domain;
using FluentValidation;
using System.Collections.Generic;
using System.Linq;

namespace Domain.FluentValidations
{
    public class RestaurantValidation : AbstractValidator<Restaurant>
    {
        public HashSet<Error> CustomValidate(Restaurant restaurant)
        {
            return Validate(restaurant).Errors.Select(f => new Error(f.PropertyName, f.ErrorMessage)).ToHashSet();
        }

        public RestaurantValidation()
        {
            RuleFor(x => x.Name)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotNull().WithMessage("Nome do restaurante deve ser informado").OverridePropertyName("Nome do restaurante")
                .NotEmpty().WithMessage("Nome do restaurante deve ser informado").OverridePropertyName("Nome do restaurante")
                .Length(1, 100).WithMessage("Nome do restaurante deve ser informado deve conter entre 1 á 100 caracteres").OverridePropertyName("Nome do restaurante");

            RuleFor(d => d.Email)
               .Cascade(CascadeMode.StopOnFirstFailure)
               .NotEmpty().WithMessage("Email deve ser informado").OverridePropertyName("Email")
               .NotNull().WithMessage("Email deve ser informado").OverridePropertyName("Email")
               .EmailAddress().WithMessage("Email invalido").OverridePropertyName("Email");

            RuleFor(s => s.CNPJ)
                .Must(x => x.IsCnpj()).WithMessage("CNPJ Invalido").OverridePropertyName("CNPJ");

            RuleFor(d => d.Password)
               .Cascade(CascadeMode.StopOnFirstFailure)
               .NotEmpty().WithMessage("Senha deve ser informado").OverridePropertyName("Senha")
               .NotNull().WithMessage("Senha deve ser informado").OverridePropertyName("Senha")
               .Length(8, 16).WithMessage("Senha deve conter entre 8 a 15 caracteres").OverridePropertyName("Senha");
        }
    }
}
