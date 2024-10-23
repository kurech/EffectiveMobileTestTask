using EffectiveMobileTestTask.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EffectiveMobileTestTask.Tests
{
    public class DataServiceTests
    {
        [Fact]
        public void LoadOrdersFromFile_ShouldReturnOrders()
        {
            var mockFilePath = "orders.csv";
            File.WriteAllText(mockFilePath,
                "OrderId,Weight,District,DeliveryDateTime\n" +
                "90e2c0cf-4fc7-43e4-b232-f6c5ae634666,2.5,Район А,2024-10-21 14:00:00\n" +
                "b032970e-ea1b-44f2-9f77-9f413b97f833,3.0,Район Б,2024-10-21 14:10:00\n");

            var dataService = new DataService();
            var orders = dataService.LoadOrdersFromFile(mockFilePath);

            Assert.Equal(2, orders.Count);
            Assert.Equal(2.5, orders[0].Weight);
            Assert.Equal("Район А", orders[0].District);

            File.Delete(mockFilePath);
        }

        [Fact]
        public void LoadOrdersFromFile_ShouldReturnEmptyList_WhenFileIsEmpty()
        {
            var mockFilePath = "orders.csv";
            File.WriteAllText(mockFilePath, "OrderId,Weight,District,DeliveryDateTime\n");

            var dataService = new DataService();
            var orders = dataService.LoadOrdersFromFile(mockFilePath);

            Assert.Empty(orders);

            File.Delete(mockFilePath);
        }

        [Fact]
        public void LoadOrdersFromFile_ShouldReturnEmptyList_WhenFileIsInvalid()
        {
            var mockFilePath = "orders.csv";
            File.WriteAllText(mockFilePath,
                "OrderId,Weight,District,DeliveryDateTime\n" +
                "00dsf,sdfsd,Район А,2024-10-21 14:00:00\n" + 
                "b032970e-ea1b-44f2-9f77-9f413b97f833,3.0,Район Б,2024-10-21 14:10:00\n");

            var dataService = new DataService();
            var orders = dataService.LoadOrdersFromFile(mockFilePath);

            Assert.Empty(orders);

            File.Delete(mockFilePath);
        }
    }
}
