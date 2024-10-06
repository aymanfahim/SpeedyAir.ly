using SpeedyAir.ly.Enums;
using SpeedyAir.ly.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeedyAir.ly.Services
{
    internal class FlightService
    {
        List<Flight> _flights = new();
        public FlightService()
        {
            FillFlights();
        }
        private void FillFlights()
        {
            _flights.Clear();
            _flights =
            [
                new Flight { Day = 1, FlightNo =1, From =LocationId.YUL, To =LocationId.YYZ },
                new Flight { Day = 1, FlightNo =2, From =LocationId.YUL, To =LocationId.YYC},
                new Flight { Day = 1, FlightNo =3, From =LocationId.YUL, To =LocationId.YVR},
                new Flight { Day = 2, FlightNo =4, From =LocationId.YUL, To =LocationId.YYZ},
                new Flight { Day = 2, FlightNo =5, From =LocationId.YUL, To =LocationId.YYC},
                new Flight { Day = 2, FlightNo =6, From =LocationId.YUL, To =LocationId.YVR},
            ];
        }
        internal List<Flight> GetFlights()
        {
            return _flights;
        }
    }
}
