using SpeedyAir.ly.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeedyAir.ly.Models
{
    internal class Flight
    {
        public int Day { get; set; }
        public int FlightNo { get; set; }
        public LocationId From { get; set; }
        public LocationId To { get; set; }
    }
}
