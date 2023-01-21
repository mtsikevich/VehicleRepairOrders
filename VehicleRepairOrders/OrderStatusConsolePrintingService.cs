namespace VehicleRepairOrders;

public class OrderStatusConsolePrintingService: IOrderStatusPrinter
{
    public void Print(OrderStatus orderStatus)
    {
        Console.WriteLine(orderStatus.ToString());
    }
}