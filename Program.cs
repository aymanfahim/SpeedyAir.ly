using SpeedyAir.ly.Enums;
using SpeedyAir.ly.Extensions;
using SpeedyAir.ly.Models;
using SpeedyAir.ly.Services;

namespace SpeedyAir.ly
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine(@"User stroy 1 running...");
            UserStory1();
            Console.WriteLine("User stroy 2 running...");
            await UserStory2();
            Console.ReadLine();
        }

        private static void UserStory1()
        {
            var flightService = new FlightService();
            var flights = flightService.GetFlights();
            foreach (var flight in flights)
            {
                Console.WriteLine($"Flight: {flight.FlightNo}, departure: {flight.From}, arrival: {flight.To}, day: {flight.Day}");
            }

        }

        private static async Task UserStory2()
        {
            var orderService = new OrderService();
            var flightService = new FlightService();
            var flights = flightService.GetFlights();
            var orderItineraries = await orderService.GetOrderItineraries(flights);
            
            foreach (var order in orderItineraries.OrderBy(o => o.OrderNo))
            {
                if (order.FlightNo > 0)
                    Console.WriteLine($"order: {order.OrderNo}, flightNumber: {order.FlightNo}, departure: {order.From.GetLocationName()}, arrival: {order.To.GetLocationName()}, day: {order.Day}");
                else
                    Console.WriteLine($"order: {order.OrderNo}, flightNumber: not scheduled");
            }
        }

    }
}
