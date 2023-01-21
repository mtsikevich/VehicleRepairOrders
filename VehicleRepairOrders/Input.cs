namespace VehicleRepairOrders;

public struct Input
{
    public bool IsRushOrder { get; set; }
    public OrderType OrderType { get; set; }
    public bool IsNewCustomer { get; set; }
    public bool IsLargeOrder { get; set; }
}