using BusinessLogicalLayer.Models.Interface;

namespace BusinessLogicalLayer.Models.DeliveryManMolder
{
    public class DeliveryManResponseModel : DeliveryManRequestModel, IResponseModel
    {
        public int Id { get; set; }
    }
}
