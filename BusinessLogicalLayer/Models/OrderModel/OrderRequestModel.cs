using System.Collections.Generic;

namespace BusinessLogicalLayer.Models.OrderModel
{
    public class OrderRequestModel
    {
        public int UserId { get; set; }
        public List<Order_SnackModel> Snacks { get; set; }
    }
}
