using EffectiveMobileTestTask.Models;
using EffectiveMobileTestTask.Services;

namespace EffectiveMobileTestTask.Tests
{
    public class OrderServiceTests
    {
        [Fact]
        public void FilterOrders_ShouldReturnCorrectOrders()
        {
            var orders = new List<Order>
            {
                new Order { Id = Guid.NewGuid(), Weight = 2.5, District = "Район А", DeliveryTime = new DateTime(2024, 10, 21, 14, 0, 0) },
                new Order { Id = Guid.NewGuid(), Weight = 3.0, District = "Район А", DeliveryTime = new DateTime(2024, 10, 21, 14, 10, 0) },
                new Order { Id = Guid.NewGuid(), Weight = 1.5, District = "Район Б", DeliveryTime = new DateTime(2024, 10, 21, 14, 20, 0) }
            };
            var orderService = new OrderService();
            var district = "Район А";
            var firstDeliveryTime = new DateTime(2024, 10, 21, 14, 0, 0);

            var result = orderService.FilterOrders(orders, district, firstDeliveryTime);
            Assert.Equal(2, result.Count());
        }

        [Fact]
        public void FilterOrders_ShouldReturnEmpty_WhenNoOrdersInSpecifiedDistrict()
        {
            var orders = new List<Order>
            {
                new Order { Id = Guid.NewGuid(), Weight = 2.5, District = "Район А", DeliveryTime = new DateTime(2024, 10, 21, 14, 0, 0) },
                new Order { Id = Guid.NewGuid(), Weight = 3.0, District = "Район А", DeliveryTime = new DateTime(2024, 10, 21, 14, 10, 0) },
                new Order { Id = Guid.NewGuid(), Weight = 1.5, District = "Район Б", DeliveryTime = new DateTime(2024, 10, 21, 14, 20, 0) }
            };
            var orderService = new OrderService();
            var district = "Район С";
            var firstDeliveryTime = new DateTime(2024, 10, 21, 14, 0, 0);

            var result = orderService.FilterOrders(orders, district, firstDeliveryTime);
            Assert.Empty(result);
        }

        [Fact]
        public void FilterOrders_ShouldReturnOrdersWithin30MinutesTimeRange()
        {
            var orders = new List<Order>
            {
                new Order { Id = Guid.NewGuid(), Weight = 2.5, District = "Район А", DeliveryTime = new DateTime(2024, 10, 21, 14, 0, 0) },
                new Order { Id = Guid.NewGuid(), Weight = 3.0, District = "Район А", DeliveryTime = new DateTime(2024, 10, 21, 14, 10, 0) },
                new Order { Id = Guid.NewGuid(), Weight = 1.5, District = "Район А", DeliveryTime = new DateTime(2024, 10, 21, 14, 35, 0) },
                new Order { Id = Guid.NewGuid(), Weight = 1.0, District = "Район А", DeliveryTime = new DateTime(2024, 10, 21, 14, 25, 0) }
            };
            var orderService = new OrderService();
            var district = "Район А";
            var firstDeliveryTime = new DateTime(2024, 10, 21, 14, 0, 0);

            var result = orderService.FilterOrders(orders, district, firstDeliveryTime);
            Assert.Equal(3, result.Count());
        }
    }
}
