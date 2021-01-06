using BusinessLogicalLayer.Models.Interface;

namespace BusinessLogicalLayer.Models.CommentRestaurantModel
{
    public class CommentRestaurantResponseModel : CommentRestaurantRequestModel, IResponseModel
    {
        public int Id { get; set; }
    }
}
