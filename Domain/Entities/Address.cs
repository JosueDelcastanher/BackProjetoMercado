using Domain.FluentValidations;
using Domain.FluentValidations.HBSIS.Padawan.Produtos.Domain;
using System.Collections.Generic;
using System.Linq;

namespace Domain.Entities
{
    public class Address : BaseEntity
    {
        //Propriedades
        public string State { get; protected set; }
        public string City { get; protected set; }
        public string Neighborhood { get; protected set; }
        public string Street { get; protected set; }
        public string Number { get; protected set; }
        public int? UserId { get; protected set; }
        public virtual User User { get; protected set; }
        public int? RestaurantId { get; protected set; }
        public virtual Restaurant Restaurant { get; protected set; }

        //Construtores
        public Address()
        {

        }
        public Address(string state, string city, string neighborhood, string street, string number)
        {
            State = state?.FormatProps();
            City = city?.FormatProps();
            Neighborhood = neighborhood?.FormatProps();
            Street = street?.FormatProps();
            Number = number?.FormatProps();
        }

        //Metodos
        public void Update(string state, string city, string neighborhood, string street, string number)
        {
            State = state?.FormatProps();
            City = city?.FormatProps();
            Neighborhood = neighborhood?.FormatProps();
            Street = street?.FormatProps();
            Number = number?.FormatProps();
        }

        public void SetRestaurant(int restaurantId)
        {
            this.RestaurantId = restaurantId;
        }

        public void SetUser(int userId)
        {
            this.UserId = userId;
        }

        public override HashSet<Error> GetErrors()
        {
            return new AddressValidation().CustomValidate(this);
        }

        public override bool IsInvalid()
        {
            return new AddressValidation().CustomValidate(this).Any();
        }
    }
}
