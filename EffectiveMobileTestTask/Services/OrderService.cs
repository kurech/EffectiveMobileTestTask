using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EffectiveMobileTestTask.Models;

namespace EffectiveMobileTestTask.Services
{
    public class OrderService
    {
        public IEnumerable<Order> FilterOrders(IEnumerable<Order> orders, string district, DateTime firstDeliveryDateTime)
        {
            return orders.Where(order => order.District == district
                                         && order.DeliveryTime >= firstDeliveryDateTime
                                         && order.DeliveryTime <= firstDeliveryDateTime.AddMinutes(30));
        }
    }
}
