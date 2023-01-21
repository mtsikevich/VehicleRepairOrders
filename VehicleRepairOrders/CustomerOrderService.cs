namespace VehicleRepairOrders;

public class CustomerOrderService: IOrderService
{
    private readonly Dictionary<Input, OrderStatus> _rules;

    public CustomerOrderService()
    {
        _rules = new Dictionary<Input, OrderStatus>
        {
            {new Input{ IsLargeOrder = true, OrderType = OrderType.Repair, IsNewCustomer = true}, OrderStatus.Closed},
            {new Input{ IsLargeOrder = true,IsRushOrder = true, OrderType = OrderType.Hire}, OrderStatus.Closed},
            {new Input{ IsLargeOrder = true, OrderType = OrderType.Repair}, OrderStatus.AuthorisationRequired},
            {new Input{ IsRushOrder = true, IsNewCustomer = true }, OrderStatus.AuthorisationRequired }
        };
    }
    
    public OrderStatus GetOrderStatus(Input input)
    {
        return _rules.ContainsKey(input) ? _rules[input] : OrderStatus.Confirmed;
    }
}