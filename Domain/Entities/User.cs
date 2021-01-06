using Domain.Entities;
using Domain.FluentValidations;
using Domain.FluentValidations.HBSIS.Padawan.Produtos.Domain;
using System.Collections.Generic;
using System.Linq;

namespace Domain
{
    public class User : BaseEntity
    {
        //Propriedades
        public string Name { get; protected set; }
        public string Email { get; protected set; }
        public string Password { get; protected set; }
        public int? AddressId { get; protected set; }
        public virtual Address Address { get; protected set; }
        public ICollection<Order> Orders { get; protected set; }
        public ICollection<CommentRestaurant> Comments { get; protected set; }

        //Construtores
        public User()
        {

        }

        public User(string name, string email, string password)
        {
            this.Name = name?.FormatProps();
            this.Email = email?.FormatProps();
            this.Password = password;
        }

        //Metodos
        public void Update(string name, string email)
        {
            this.Name = name?.FormatProps();
            this.Email = email?.FormatProps();
        }

        public void ChangePassword(string password)
        {
            this.Password = password;
        }

        public void HashPassword()
        {
            this.Password = HashService.HashString(this.Password);
        }

        public override HashSet<Error> GetErrors()
        {
            return new UserValidation().CustomValidate(this);
        }

        public override bool IsInvalid()
        {
            return new UserValidation().CustomValidate(this).Any();
        }
    }
}
