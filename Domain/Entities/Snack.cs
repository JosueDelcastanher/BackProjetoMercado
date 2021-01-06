using Domain.FluentValidations;
using Domain.FluentValidations.HBSIS.Padawan.Produtos.Domain;
using System.Collections.Generic;
using System.Linq;

namespace Domain.Entities
{
    public class Snack : BaseEntity
    {
        //Propriedades
        public string Name { get; protected set; }
        public string ImagePath { get; protected set; }
        public double Price { get; protected set; }
        public string Description { get; protected set; }
        public int? RestaurantId { get; protected set; }
        public virtual Restaurant Restaurant { get; protected set; }
        public virtual ICollection<Order_Snack> Orders { get; protected set; }

        //Construtores
        public Snack()
        {

        }
        public Snack(string name, string description, double price)
        {
            this.Name = name?.FormatProps();
            this.Description = description?.FormatProps();
            this.Price = price;
        }

        //Metodos
        public void Update(string name, string description, double price)
        {
            this.Name = name?.FormatProps();
            this.Description = description?.FormatProps();
            this.Price = price;
        }

        public void SetRestaurantId(int restaurantId)
        {
            this.RestaurantId = restaurantId;
        }

        public void SetImagePath(string imagePath)
        {
            this.ImagePath = imagePath;
        }

        public override HashSet<Error> GetErrors()
        {
            return new SnackValidation().CustomValidate(this);
        }

        public override bool IsInvalid()
        {
            return new SnackValidation().CustomValidate(this).Any();
        }
    }
}
