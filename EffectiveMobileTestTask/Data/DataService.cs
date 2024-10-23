using System.Globalization;
using EffectiveMobileTestTask.Models;

namespace EffectiveMobileTestTask.Data
{
    public class DataService
    {
        public List<Order> LoadOrdersFromFile(string filePath)
        {
            var orders = new List<Order>();

            try
            {
                using (var reader = new StreamReader(filePath))
                {
                    string line;
                    bool isFirstLine = true;

                    while ((line = reader.ReadLine()) != null)
                    {
                        if (isFirstLine)
                        {
                            isFirstLine = false;
                            continue;
                        }

                        var values = line.Split(',');

                        if (values.Length != 4)
                        {
                            throw new FormatException("Неверное количество полей в данных заказа.");
                        }

                        var order = new Order
                        {
                            Id = Guid.Parse(values[0]),
                            Weight = double.Parse(values[1], CultureInfo.InvariantCulture),
                            District = values[2],
                            DeliveryTime = DateTime.ParseExact(values[3], "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture)
                        };

                        if (order.Weight <= 0)
                        {
                            throw new ArgumentException("Вес заказа должен быть положительным числом.");
                        }

                        orders.Add(order);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при чтении файла: {ex.Message}");
            }

            return orders;
        }

        public void SaveResultsToFile(string filePath, IEnumerable<Order> orders)
        {
            try
            {
                using (var writer = new StreamWriter(filePath, append: true))
                {
                    writer.WriteLine($":: {DateTime.Now:yyyy-MM-dd HH:mm:ss}");
                    writer.WriteLine(new string('-', 50));

                    foreach (var order in orders)
                    {
                        writer.WriteLine($"Идентификатор: {order.Id}, Вес: {order.Weight} кг, Район: {order.District}, Время доставки: {order.DeliveryTime:yyyy-MM-dd HH:mm:ss}");
                    }

                    writer.WriteLine();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при записи файла: {ex.Message}");
            }
        }
    }
}
