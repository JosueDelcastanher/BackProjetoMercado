using Domain.FluentValidations;
using Domain.FluentValidations.HBSIS.Padawan.Produtos.Domain;
using System.Collections.Generic;
using System.Linq;

namespace Domain.Entities
{
    public class CommentRestaurant : BaseEntity
    {
        public int RestaurantId { get; protected set; }
        public virtual Restaurant Restaurant { get; protected set; }
        public string Commentary { get; protected set; }
        public int UserId { get; protected set; }
        public bool IsGood { get; protected set; }
        public virtual User User { get; set; }

        public CommentRestaurant()
        {

        }

        public CommentRestaurant(int restaurantId, string commentary, int userId, bool isGood)
        {
            RestaurantId = restaurantId;
            Commentary = commentary?.FormatProps();
            UserId = userId;
            IsGood = isGood;
        }

        public void Update(string commentary, bool isGood)
        {
            Commentary = commentary?.FormatProps();
            IsGood = isGood;
        }

        public void SetRestaurantId(int restaurantId)
        {
            this.RestaurantId = restaurantId;
        }

        public override HashSet<Error> GetErrors()
        {
            return new CommentRestaurantValidation().CustomValidate(this);
        }

        public override bool IsInvalid()
        {
            return new CommentRestaurantValidation().CustomValidate(this).Any();
        }
    }
}
