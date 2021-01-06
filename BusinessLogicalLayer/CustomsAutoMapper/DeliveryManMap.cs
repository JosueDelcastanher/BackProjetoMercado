using BusinessLogicalLayer.Models.DeliveryManMolder;
using Domain.Entities;
using Shared;

namespace BusinessLogicalLayer.CustomsAutoMapper
{
    public static class DeliveryManMap
    {
        public static DeliveryMan DeliveryManRequestModelToDeliveryMan(DeliveryManRequestModel deliveryManModel)
        {
            return Map.ChangeValues<DeliveryManRequestModel, DeliveryMan>(deliveryManModel);
        }

        public static DeliveryManResponseModel DeliveryManToDeliveryManResponse(DeliveryMan deliveryMan)
        {
            return Map.ChangeValues<DeliveryMan, DeliveryManResponseModel>(deliveryMan);
        }
    }
}
