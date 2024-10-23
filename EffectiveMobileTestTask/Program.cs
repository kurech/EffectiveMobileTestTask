using EffectiveMobileTestTask;
using EffectiveMobileTestTask.Data;
using EffectiveMobileTestTask.Logging;
using EffectiveMobileTestTask.Services;

class Program
{
    static void Main(string[] args)
    {
        if (args.Length < 5)
        {
            Console.WriteLine("Используй такой вызов: <program> <cityDistrict> <firstDeliveryDateTime> <logFilePath> <ordersFilePath> <resultFilePath>");
            return;
        }

        try
        {
            var cityDistrict = args[0];
            var firstDeliveryDateTime = DateTime.Parse(args[1]);
            var logFilePath = args[2];
            var ordersFilePath = args[3];
            var resultFilePath = args[4];

            var dataService = new DataService();
            var orders = dataService.LoadOrdersFromFile(ordersFilePath);

            Logger.Log($"Загружены {orders.Count} заказов из {ordersFilePath}", logFilePath);

            var orderService = new OrderService();
            var filteredOrders = orderService.FilterOrders(orders, cityDistrict, firstDeliveryDateTime);

            if (filteredOrders.Any())
            {
                dataService.SaveResultsToFile(resultFilePath, filteredOrders);
                Logger.Log($"Отфильтрован(ы) {filteredOrders.Count()} заказ(а) для района {cityDistrict} и сохранен в {resultFilePath}", logFilePath);
            }
            else
            {
                Logger.Log($"Не найдено заказов для района {cityDistrict} за указанный промежуток времени.", logFilePath);
            }

            Console.WriteLine("Выполнено!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Произошла ошибка: {ex.Message}");
        }
    }
}
