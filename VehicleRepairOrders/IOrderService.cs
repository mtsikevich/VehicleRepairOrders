namespace VehicleRepairOrders;

public interface IOrderService
{
    OrderStatus GetOrderStatus(Input input);
}