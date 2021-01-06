using BusinessLogicalLayer.Models.OrderModel;
using Domain.Entities;

namespace BusinessLogicalLayer.CustomsAutoMapper
{
    public static class OrderMap
    {
        public static Order OrderRequestToOrder(OrderRequestModel orderRequestModel)
        {
            return new Order(orderRequestModel.UserId);
        }

        public static OrderResponseModel OrderToOrderResponse(Order order)
        {
            return new OrderResponseModel()
            {
                Id = order.Id,
                UserId = order.UserId,
                RestaurantId = order.RestaurantId,
                IsPaid = order.IsPaid,
                DeliveryManId = order.DeliveryManId
            };
        }
    }
}
