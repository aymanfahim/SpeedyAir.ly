using SpeedyAir.ly.Enums;
using SpeedyAir.ly.Extensions;
using SpeedyAir.ly.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SpeedyAir.ly.Services
{
    internal class OrderService
    {
        private const int _flightCapacity = 20;
        public OrderService()
        {

        }

        internal async Task<IEnumerable<OrderItineraries>> GetOrderItineraries(List<Flight> flights)
        {
            var orders = await GetOrders();
            List<OrderItineraries> orderItineraries = new List<OrderItineraries>();
            foreach (var flight in flights)
            {
                var orderForFlight = orders.Where(x => x.LocationID == flight.To).Skip((flight.Day - 1) * _flightCapacity).Take(_flightCapacity);
                orderItineraries.AddRange(orderForFlight.Select(o => new OrderItineraries
                {
                    OrderNo = o.OrderID,
                    FlightNo = flight.FlightNo,
                    From = flight.From,
                    To = flight.To,
                    Day = flight.Day
                }));
            }

            //add orders with no scheduled flights
            orderItineraries.AddRange(orders.Where(o => !orderItineraries.Select(x => x.OrderNo).Contains(o.OrderID))
                .Select(o => new OrderItineraries { OrderNo = o.OrderID }));
            return orderItineraries;
        }
        private async Task<IEnumerable<Order>> GetOrders()
        {
            var rawOrdersData = await LoadOrdersDataFromFile();
            return ConstructOrderList(rawOrdersData);
        }

        private async Task<Dictionary<string, DestinationData>> LoadOrdersDataFromFile()
        {
            return await JsonFileReader.ReadJsonAsync<Dictionary<string, DestinationData>>(Path.Combine(AppContext.BaseDirectory + @"Data\", "coding-assigment-orders.json"));
        }

        private IEnumerable<Order> ConstructOrderList(Dictionary<string, DestinationData> rawOrderData)
        {
            return rawOrderData.Select(r => new Order
            {
                OrderID = r.Key,
                LocationID = r.Value.Destination.GetLocationId()//Enum.Parse<LocationId>(r.Value.Destination, false)
            });
        }

        
    }
}
