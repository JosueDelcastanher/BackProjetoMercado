using BusinessLogicalLayer.Models.Interface;

namespace BusinessLogicalLayer.Models.AddressModel
{
    public class AddressResponseModel : AddressRequestModel, IResponseModel
    {
        public int Id { get; set; }
        public int ResturantId { get; set; }
    }
}
