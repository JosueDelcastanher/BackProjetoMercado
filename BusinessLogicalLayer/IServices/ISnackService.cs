using BusinessLogicalLayer.Models.SnackModel;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogicalLayer.IServices
{
    public interface ISnackService
    {
        Task<SnackResponseModel> Update(int restaurantId, int id, SnackUpdateModel model);
        Task<ICollection<SnackResponseModel>> GetByRestaurantId(int restaurantId);
        Task<SnackResponseModel> Create(int restaurantId, SnackRequestModel model, IFormFile image);
        Task<SnackResponseModel> GetById(int restaurantId, int id);
        Task<SnackResponseModel> Delete(int restaurantId, int id);
    }
}