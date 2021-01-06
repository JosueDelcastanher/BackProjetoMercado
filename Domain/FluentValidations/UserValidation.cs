using Domain.FluentValidations.HBSIS.Padawan.Produtos.Domain;
using FluentValidation;
using System.Collections.Generic;
using System.Linq;

namespace Domain.FluentValidations
{
    class UserValidation : AbstractValidator<User>
    {
        public HashSet<Error> CustomValidate(User user)
        {
            return Validate(user).Errors.Select(f => new Error(f.PropertyName, f.ErrorMessage)).ToHashSet();
        }

        public UserValidation()
        {
            RuleFor(d => d.Name)
               .Cascade(CascadeMode.StopOnFirstFailure)
               .NotEmpty().WithMessage("Nome deve ser informado").OverridePropertyName("Nome")
               .NotNull().WithMessage("Nome deve ser informado").OverridePropertyName("Nome")
               .Length(2, 100).WithMessage("Nome deve conter entre 2 a 100 caracteres").OverridePropertyName("Nome");

            RuleFor(d => d.Email)
               .Cascade(CascadeMode.StopOnFirstFailure)
               .NotEmpty().WithMessage("Email deve ser informado").OverridePropertyName("Email")
               .NotNull().WithMessage("Email deve ser informado").OverridePropertyName("Email")
               .EmailAddress().WithMessage("Email invalido").OverridePropertyName("Email");

            RuleFor(d => d.Password)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty().WithMessage("Senha deve ser informado").OverridePropertyName("Senha")
                .NotNull().WithMessage("Senha deve ser informado").OverridePropertyName("Senha")
                .Length(8, 100).WithMessage("Senha deve conter entre 8 a 100 caracteres").OverridePropertyName("Senha");
        }
    }
}
