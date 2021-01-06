using BusinessLogicalLayer.Models.RestaurantModel;
using Domain.Entities;
using Shared;

namespace BusinessLogicalLayer.CustomsAutoMapper
{
    public static class RestaurantMap
    {
        public static Restaurant RestaurantRequestToRestaurant(RestaurantRequestModel restaurantRequest)
        {
            return Map.ChangeValues<RestaurantRequestModel, Restaurant>(restaurantRequest);
        }

        public static RestaurantResponseModel RestaurantToRestaurantResponse(Restaurant restaurant)
        {
            return Map.ChangeValues<Restaurant, RestaurantResponseModel>(restaurant);
        }
    }
}
