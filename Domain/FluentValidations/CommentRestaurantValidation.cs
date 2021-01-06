using Domain.Entities;
using Domain.FluentValidations.HBSIS.Padawan.Produtos.Domain;
using FluentValidation;
using System.Collections.Generic;
using System.Linq;

namespace Domain.FluentValidations
{
    public class CommentRestaurantValidation : AbstractValidator<CommentRestaurant>
    {
        public HashSet<Error> CustomValidate(CommentRestaurant comment)
        {
            return Validate(comment).Errors.Select(f => new Error(f.PropertyName, f.ErrorMessage)).ToHashSet();
        }

        public CommentRestaurantValidation()
        {
            RuleFor(a => a.Commentary)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotNull().WithMessage("Comentario deve ser informado").OverridePropertyName("Comentario")
                .NotEmpty().WithMessage("Comentario deve ser informado").OverridePropertyName("Comentario")
                .Length(2, 255).WithMessage("Comentario deve conter entre 2 á 255 caracteres").OverridePropertyName("Comentario");

            RuleFor(a => a.RestaurantId)
               .Cascade(CascadeMode.StopOnFirstFailure)
               .GreaterThan(0).WithMessage("Restaurante invalido").OverridePropertyName("Restaurante");

            RuleFor(a => a.UserId)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty().WithMessage("Usuario deve ser informado").OverridePropertyName("Usuario")
                .GreaterThan(0).WithMessage("Usuario invalido").OverridePropertyName("Usuario");
        }
    }
}
