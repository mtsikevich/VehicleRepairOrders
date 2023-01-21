using Microsoft.Extensions.DependencyInjection;

namespace VehicleRepairOrders;

public class Program
{
    public static void Main(string[] args)
    {
        var serviceProvider = new ServiceCollection()
            .AddSingleton<IOrderStatusPrinter, OrderStatusConsolePrintingService>()
            .AddSingleton<IOrderService, CustomerOrderService>()
            .BuildServiceProvider();

        RunApplication(serviceProvider);
    }

    private static void RunApplication(IServiceProvider serviceProvider)
    {
        var customerOrderService = serviceProvider.GetService<IOrderService>()!;
        var orderStatusPrinter = serviceProvider.GetService<IOrderStatusPrinter>()!;
        var inputs = new Input();

        do
        {
            Console.Write("Is it a rush order? true | false: ");
            inputs.IsRushOrder = bool.Parse(Console.ReadLine()!);
            Console.Write("What is the order type? Repair | Hire:");
            inputs.OrderType = Enum.Parse<OrderType>(Console.ReadLine()!);
            Console.Write("Is the customer new? true | false: ");
            inputs.IsNewCustomer = bool.Parse(Console.ReadLine()!);
            Console.Write("Is the order large? true | false: ");
            inputs.IsLargeOrder = bool.Parse(Console.ReadLine()!);

            var orderStatus = customerOrderService.GetOrderStatus(inputs);
            orderStatusPrinter.Print(orderStatus);

            Console.Clear();
        } while (true);
    }
}