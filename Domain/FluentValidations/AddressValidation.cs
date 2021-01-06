using Domain.Entities;
using Domain.FluentValidations.HBSIS.Padawan.Produtos.Domain;
using FluentValidation;
using System.Collections.Generic;
using System.Linq;

namespace Domain.FluentValidations
{
    public class AddressValidation : AbstractValidator<Address>
    {
        public HashSet<Error> CustomValidate(Address address)
        {
            return Validate(address).Errors.Select(f => new Error(f.PropertyName, f.ErrorMessage)).ToHashSet();
        }

        public AddressValidation()
        {
            RuleFor(a => a.Number)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotNull().WithMessage("Numero do endereço deve ser informado").OverridePropertyName("Numero do endereço")
                .NotEmpty().WithMessage("Numero do endereço deve ser informado").OverridePropertyName("Numero do endereço")
                .Length(1, 6).WithMessage("Numero do endereço deve conter entre 1 á 6 caracteres").OverridePropertyName("Numero do endereço");

            RuleFor(a => a.Street)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotNull().WithMessage("Rua deve ser informado").OverridePropertyName("Rua")
                .NotEmpty().WithMessage("Rua deve ser informado").OverridePropertyName("Rua")
                .Length(2, 100).WithMessage("Rua deve conter entre 2 á 100 caracteres").OverridePropertyName("Rua");

            RuleFor(a => a.Neighborhood)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotNull().WithMessage("Bairro deve ser informado").OverridePropertyName("Bairro")
                .NotEmpty().WithMessage("Bairro deve ser informado").OverridePropertyName("Bairro")
                .Length(2, 100).WithMessage("Rua deve conter entre 2 á 100 caracteres").OverridePropertyName("Bairro");

            RuleFor(a => a.City)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotNull().WithMessage("Cidade deve ser informado").OverridePropertyName("Cidade")
                .NotEmpty().WithMessage("Cidade deve ser informado").OverridePropertyName("Cidade")
                .Length(2, 100).WithMessage("Cidade deve conter entre 2 á 100 caracteres").OverridePropertyName("Cidade");

            RuleFor(a => a.State)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotNull().WithMessage("Estado deve ser informado").OverridePropertyName("Estado")
                .NotEmpty().WithMessage("Estado deve ser informado").OverridePropertyName("Estado")
                .Length(2, 100).WithMessage("Estado deve conter entre 2 á 100 caracteres").OverridePropertyName("Estado");

            RuleFor(a => a.UserId)
                .GreaterThan(0).WithMessage("Usuario invalido").OverridePropertyName("Usuario");

            RuleFor(a => a.RestaurantId)
                 .GreaterThan(0).WithMessage("Usuario invalido").OverridePropertyName("Restaurant");
        }
    }
}
