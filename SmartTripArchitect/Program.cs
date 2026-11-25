using SmartTripArchitect.Routes;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace SmartTripArchitect
{
    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            var planner = new TripPlanner(new Dictionary<RouteType, ITripRouteStrategy>
            {
                [RouteType.Fastest] = new FastestRouteStrategy(),
                [RouteType.Scenic] = new ScenicRouteStrategy(),
                [RouteType.Budget] = new BudgetRouteStrategy()
            });

            var requests = new[]
            {
                new TripRequest(1, "Rossio", "Belém", City.Lisbon, 10, RouteType.Fastest, false, false),
                new TripRequest(2, "Oriente", "Alcântara", City.Lisbon, 12, RouteType.Budget, true, false),
                new TripRequest(3, "Praça do Comércio", "Jardim da Estrela", City.Lisbon, 5, RouteType.Scenic, false, true),
                new TripRequest(4, "Dublin Airport", "Temple Bar", City.Dublin, 11, RouteType.Fastest, true, true),
                new TripRequest(5, "Phoenix Park", "Sandymount", City.Dublin, 9, RouteType.Budget, false, false),
                new TripRequest(6, "Trinity College", "Grand Canal Dock", City.Dublin, 2.5, RouteType.Scenic, false, false)
            };

            foreach (var request in requests)
            {
                TripReport report = planner.Plan(request);
                Console.WriteLine(report);
                Console.WriteLine();
            }
        }
    }
}