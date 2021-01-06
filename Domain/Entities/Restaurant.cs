using Domain.FluentValidations;
using Domain.FluentValidations.HBSIS.Padawan.Produtos.Domain;
using System.Collections.Generic;
using System.Linq;

namespace Domain.Entities
{
    public class Restaurant : BaseEntity
    {

        public string Name { get; protected set; }
        public string ImagePath { get; protected set; }
        public string CNPJ { get; protected set; }
        public string Password { get; protected set; }
        public string Email { get; protected set; }
        public int? AddressId { get; protected set; }
        public virtual Address Address { get; protected set; }
        public virtual ICollection<Snack> Snacks { get; protected set; }
        public virtual ICollection<Order> Orders { get; protected set; }
        public virtual ICollection<CommentRestaurant> Comments { get; protected set; }

        public Restaurant()
        {

        }

        public Restaurant(string name, string cNPJ, string password, string email)
        {
            this.Name = name?.FormatProps();
            this.CNPJ = cNPJ?.FormatProps();
            this.Password = password;
            this.Email = email?.FormatProps();
        }

        public void Update(string name, string email)
        {
            this.Name = name?.FormatProps();
            this.Email = email?.FormatProps();
        }

        public void ChangePassword(string password)
        {
            this.Password = password;
        }

        public void SetImagePath(string imagePath)
        {
            this.ImagePath = imagePath;
        }

        public void HashPassword()
        {
            this.Password = HashService.HashString(this.Password);
        }

        public override HashSet<Error> GetErrors()
        {
            return new RestaurantValidation().CustomValidate(this);
        }

        public override bool IsInvalid()
        {
            return new RestaurantValidation().CustomValidate(this).Any();
        }
    }
}
