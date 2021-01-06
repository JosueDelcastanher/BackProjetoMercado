using BusinessLogicalLayer.CustomsAutoMapper;
using BusinessLogicalLayer.IServices;
using BusinessLogicalLayer.Models.OrderModel;
using Domain.Entities;
using Infra.IRepositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;

namespace BusinessLogicalLayer.Services
{
    public class OrderService : BaseService<Order>, IOrderService
    {

        private readonly IOrderRepository _orderRepository;
        private readonly IDeliveryManRepository _deliveryManRepository;
        private readonly IUserRepository _userRepository;
        private readonly ISnackRepository _snackRepository;
        private readonly IRestaurantRepository _restaurantRepository;
        private readonly IOrder_SnackRepository _order_SnackRepository;

        public OrderService(IOrderRepository orderRepository,
                            IDeliveryManRepository deliveryManRepository,
                            IUserRepository userRepository,
                            ISnackRepository snackRepository,
                            IRestaurantRepository restaurantRepository,
                            IOrder_SnackRepository order_SnackRepository)
        {
            _orderRepository = orderRepository;
            _deliveryManRepository = deliveryManRepository;
            _userRepository = userRepository;
            _snackRepository = snackRepository;
            _restaurantRepository = restaurantRepository;
            _order_SnackRepository = order_SnackRepository;
        }

        public async Task<OrderResponseModel> AddDelivery(int restaurantId, int orderId, int deliveryId)
        {
            ValidateId(orderId);
            ValidateId(deliveryId);
            ValidateId(restaurantId);

            HandleError();

            var deliveryMan = await _deliveryManRepository.GetById(deliveryId);

            if (deliveryMan == null)
                AddError("Entregador", "Não encontrado");

            var order = await _orderRepository.GetById(orderId);

            if (order == null || order.RestaurantId != restaurantId)
                AddError("Pedido", "Não encontrado");

            HandleError();

            order.AddDeliveryMan(deliveryId);

            await _orderRepository.Update(order);
            await _orderRepository.Save();

            return OrderMap.OrderToOrderResponse(order);
        }

        public async Task<OrderResponseModel> Create(int restaurantId, OrderRequestModel orderModel)
        {
            var order = OrderMap.OrderRequestToOrder(orderModel);
            order.SetRestaurantId(restaurantId);

            Validate(order);

            var user = await _userRepository.GetById(order.UserId);

            if (user == null || user.AddressId == 0)
                AddError("Usuario", "Invalido");

            var restaurant = await _restaurantRepository.GetById(restaurantId);

            if (restaurant == null || restaurant.AddressId == 0)
                AddError("Restaurante", "Invalido");

            HandleError();

            using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                await _orderRepository.Create(order);
                await _orderRepository.Save();

                foreach (var snack in orderModel.Snacks)
                {

                    var snackOrder = await _snackRepository.GetById(snack.SnackId);

                    if (snackOrder == null || snackOrder.RestaurantId != restaurantId)
                        AddError("Lanche", "Não encontrado");

                    HandleError();

                    var snack_order = new Order_Snack(order.Id, snackOrder.Id, snack.Quantity);

                    await _order_SnackRepository.Create(snack_order);
                }

                await _order_SnackRepository.Save();
                scope.Complete();
            }

            return OrderMap.OrderToOrderResponse(order);
        }

        public async Task<OrderResponseModel> Delete(int restaurantId, int id)
        {
            var order = await _orderRepository.GetById(id);

            if (order == null || order.RestaurantId != restaurantId)
                AddError("Pedido", "Invalido");

            HandleError();

            await _orderRepository.Delete(id);
            await _orderRepository.Save();

            return OrderMap.OrderToOrderResponse(order);
        }

        public async Task<OrderResponseModel> GetById(int restaurantId, int id)
        {
            var order = await _orderRepository.GetById(id);

            if (order == null || order.RestaurantId != restaurantId)
                AddError("Pedido", "Invalido");

            HandleError();

            return OrderMap.OrderToOrderResponse(order);
        }

        public async Task<List<OrderResponseModel>> GetByRestaurantId(int restaurantId)
        {
            var orders = await _orderRepository.GetByRestaurantId(restaurantId);
            return orders.Select(x => OrderMap.OrderToOrderResponse(x)).ToList();
        }

        public async Task<List<OrderResponseModel>> GetPaidsByRestaurantId(int restaurantId)
        {
            var orders = await _orderRepository.GetPaidsByRestaurantId(restaurantId);
            return orders.Select(x => OrderMap.OrderToOrderResponse(x)).ToList();
        }

        public async Task<List<OrderResponseModel>> GetUnPaidsByRestaurantId(int restaurantId)
        {
            var orders = await _orderRepository.GetUnPaidsByRestaurantId(restaurantId);
            return orders.Select(x => OrderMap.OrderToOrderResponse(x)).ToList();
        }

        public async Task<OrderResponseModel> PayOrder(int restaurantId, int id)
        {
            var order = await _orderRepository.GetById(id);

            if (order == null || order.RestaurantId != restaurantId)
                AddError("Pedido", "Invalido");

            HandleError();

            if (order.IsPaid)
                AddError("Pedido", "Já pago");

            HandleError();

            order.Pay();

            await _orderRepository.Update(order);
            await _orderRepository.Save();

            return OrderMap.OrderToOrderResponse(order);
        }

        public override void Validate(Order entity)
        {
            if (entity.IsInvalid())
                AddErrors(entity.GetErrors());

            HandleError();
        }
    }
}
