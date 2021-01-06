using BusinessLogicalLayer.Models.RestaurantModel;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogicalLayer.IServices
{
    public interface IRestaurantService
    {
        Task<ICollection<RestaurantResponseModel>> GetAll();
        Task<RestaurantResponseModel> GetById(int id);
        Task<RestaurantResponseModel> Create(RestaurantRequestModel restaurantModel, IFormFile image);
        Task<RestaurantResponseModel> Update(int id, RestaurantUpdateRequestModel restaurantUpdateModel);
        Task<RestaurantResponseModel> Delete(int id);
        Task<RestaurantResponseModel> Login(RestaurantLoginRequestModel restaurantLoginModel);
        Task<RestaurantResponseModel> ChangePassword(int userId, RestaurantPasswordRequestModel restaurantPasswordModel);
    }
}
