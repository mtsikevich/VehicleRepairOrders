using FluentAssertions;

namespace VehicleRepairOrders.Unit.Tests;

public class CustomerOrderServiceTests
{
    [Theory]
    [ClassData(typeof(RuledInputData))]
    public void GetOrderStatus_ForInputWithSpecificRules(Input inputEntry, OrderStatus status)
    {
        var customerOrderService = new CustomerOrderService();
        var orderStatus = customerOrderService.GetOrderStatus(inputEntry);

        orderStatus.Should().Be(status);
    }
}

class RuledInputData : TheoryData<Input, OrderStatus>
{
    public RuledInputData()
    {
        Add(new Input{ IsLargeOrder = true, OrderType = OrderType.Repair, IsNewCustomer = true}, OrderStatus.Closed);
        Add(new Input{ IsLargeOrder = true,IsRushOrder = true, OrderType = OrderType.Hire}, OrderStatus.Closed);
        Add(new Input{ IsLargeOrder = true, OrderType = OrderType.Repair}, OrderStatus.AuthorisationRequired);
        Add(new Input{ IsRushOrder = true, IsNewCustomer = true }, OrderStatus.AuthorisationRequired);
    }
}
