using FluentAssertions;

namespace VehicleRepairOrders.Unit.Tests;

public class OrderStatusConsolePrintingServiceTests
{
    [Theory]
    [MemberData(nameof(Data))]
    public void Print_ShouldPrintTheOrderStatusAsAStringOnTheConsole(OrderStatus status, string expected)
    {
        var consoleWriteOutput = new StringWriter();
        Console.SetOut(consoleWriteOutput);

        var orderStatusConsolePrintingService = new OrderStatusConsolePrintingService();
        orderStatusConsolePrintingService.Print(status);

        consoleWriteOutput.ToString().Trim().Should().Be(expected);
    }

    public static IEnumerable<object[]> Data =>
        new List<object[]>
        {
            new object[] { OrderStatus.Closed, OrderStatus.Closed.ToString() },
            new object[] { OrderStatus.Confirmed, OrderStatus.Confirmed.ToString() },
            new object[] { OrderStatus.AuthorisationRequired, OrderStatus.AuthorisationRequired.ToString() }
        };
}

