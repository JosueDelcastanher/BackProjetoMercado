using BusinessLogicalLayer.Models.CommentRestaurantModel;
using Domain.Entities;
using Shared;

namespace BusinessLogicalLayer.CustomsAutoMapper
{
    public static class CommentRestaurantMap
    {
        public static CommentRestaurant CommentRestaurantRequestToCommentRestaurant(CommentRestaurantRequestModel commentRestaurantRequest)
        {
            return Map.ChangeValues<CommentRestaurantRequestModel, CommentRestaurant>(commentRestaurantRequest);
        }

        public static CommentRestaurantResponseModel CommentRestaurantToCommentRestaurantResponse(CommentRestaurant commentRestaurant)
        {
            return Map.ChangeValues<CommentRestaurant, CommentRestaurantResponseModel>(commentRestaurant);
        }
    }
}
