using Domain.FluentValidations.HBSIS.Padawan.Produtos.Domain;
using System.Collections.Generic;

namespace Domain.Entities
{
    public abstract class BaseEntity
    {
        public int Id { get; private set; }
        public bool Deleted { get; private set; }

        public void DeleteItem()
        {
            this.Deleted = true;
        }

        public abstract HashSet<Error> GetErrors();
        public abstract bool IsInvalid();
    }
}
