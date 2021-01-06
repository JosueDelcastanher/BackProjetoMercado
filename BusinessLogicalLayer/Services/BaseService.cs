using Domain.Entities;
using Domain.FluentValidations.HBSIS.Padawan.Produtos.Domain;
using Shared.CustomsExceptions;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLogicalLayer.Services
{
    public abstract class BaseService<T> where T : BaseEntity
    {
        public HashSet<Error> Errors { get; private set; } = new HashSet<Error>();

        public bool HasError()
        {
            return Errors.Any();
        }

        public void HandleError()
        {
            if (HasError())
                throw new BadRequestException(Errors);
        }

        public void AddError(string fieldName, string message)
        {
            Errors.Add(new Error(fieldName, message));
        }

        public void AddErrors(HashSet<Error> errors)
        {
            Errors = Errors.Union(errors).ToHashSet();
        }

        public void ValidateId(int id)
        {
            if (id < 1)
                AddError("Id", "Invalido");
        }

        public abstract void Validate(T entity);
    }
}
