using BusinessLogicalLayer.Models.Interface;

namespace BusinessLogicalLayer.Models.SnackModel
{
    public class SnackResponseModel : SnackRequestModel, IResponseModel
    {
        public int Id { get; set; }
        public int RestaurantId { get; set; }
        public string ImagePath { get; set; }
    }
}
