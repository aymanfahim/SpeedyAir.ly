using SpeedyAir.ly.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeedyAir.ly.Models
{
    internal class OrderItineraries
    {
        //order: order-001, flightNumber: 1, departure: <departure_city>, arrival: <arrival_city>, day: x

        public required string OrderNo { get; set; }
        public int FlightNo { get; set; }
        public LocationId From { get; set; }
        public LocationId To { get; set; }
        public int Day { get; set; }
    }
}
