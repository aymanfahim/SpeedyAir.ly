using SpeedyAir.ly.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeedyAir.ly.Models
{
    internal class Order
    {
        public required string OrderID { get; set; }
        public LocationId LocationID { get; set; }
    }
}
