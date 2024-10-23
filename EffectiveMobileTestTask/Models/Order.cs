using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EffectiveMobileTestTask.Models
{
    public class Order
    {
        public Guid Id { get; set; }
        public double Weight { get; set; }
        public required string District { get; set; }
        public DateTime DeliveryTime { get; set; }
    }
}
