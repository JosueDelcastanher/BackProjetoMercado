using Domain.FluentValidations;
using Domain.FluentValidations.HBSIS.Padawan.Produtos.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Domain.Entities
{
    public class Order : BaseEntity
    {
        //Propriedades
        public DateTime DateTime { get; protected set; }
        public int UserId { get; protected set; }
        public virtual User User { get; protected set; }
        public virtual ICollection<Order_Snack> Snacks { get; protected set; }
        public int? DeliveryManId { get; protected set; }
        public virtual DeliveryMan DeliveryMan { get; protected set; }
        public int RestaurantId { get; protected set; }
        public virtual Restaurant Restaurant { get; protected set; }
        public bool IsPaid { get; protected set; }

        //Construtores
        public Order()
        {
        }
        public Order(int userId)
        {
            this.DateTime = DateTime.UtcNow;
            this.UserId = userId;
        }

        public void AddDeliveryMan(int deliveryManId)
        {
            this.DeliveryManId = deliveryManId;
        }

        public void Pay()
        {
            this.IsPaid = true;
        }

        public void SetRestaurantId(int restaurantId)
        {
            this.RestaurantId = restaurantId;
        }

        public void SetUserId(int userId)
        {
            this.UserId = userId;
        }

        public override HashSet<Error> GetErrors()
        {
            return new OrderValidation().CustomValidate(this);
        }

        public override bool IsInvalid()
        {
            return new OrderValidation().CustomValidate(this).Any();
        }
    }
}
