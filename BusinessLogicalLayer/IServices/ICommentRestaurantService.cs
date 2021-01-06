using BusinessLogicalLayer.Models.CommentRestaurantModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogicalLayer.IServices
{
    public interface ICommentRestaurantService
    {
        Task<List<CommentRestaurantResponseModel>> GetAll();
        Task<CommentRestaurantResponseModel> GetById(int restaurantId, int id);
        Task<CommentRestaurantResponseModel> Create(int restaurantId, CommentRestaurantRequestModel commentModel);
        Task<CommentRestaurantResponseModel> Update(int restaurantId, CommentUpdateModel commentModel, int id);
        Task<CommentRestaurantResponseModel> Delete(int restaurantId, int id);
        Task<ICollection<CommentRestaurantResponseModel>> GetByRestaurantId(int restaurantId);
    }
}
