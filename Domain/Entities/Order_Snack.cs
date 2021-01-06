namespace Domain.Entities
{
    public class Order_Snack
    {

        public int OrderId { get; protected set; }
        public virtual Order Order { get; protected set; }
        public int SnackId { get; protected set; }
        public virtual Snack Snack { get; protected set; }
        public int Quantity { get; protected set; }

        public Order_Snack()
        {

        }

        public Order_Snack(int orderId, int snackId, int quantity)
        {
            OrderId = orderId;
            SnackId = snackId;
            Quantity = quantity;
        }
    }
}
