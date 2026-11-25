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
                [RouteType.Budget] = new BudgetRouteStrategy(),
                [RouteType.Eco] = new EcoRouteStrategy()
            });

            var requests = new[]
            {
                new TripRequest(1, "Rossio", "Belém", City.Lisbon, 10, RouteType.Fastest),
                new TripRequest(2, "Oriente", "Alcântara", City.Lisbon, 12, RouteType.Budget, TripOption.Insurance),
                new TripRequest(3, "Praça do Comércio", "Jardim da Estrela", City.Lisbon, 5, RouteType.Scenic, TripOption.AudioGuide),
                new TripRequest(4, "Dublin Airport", "Temple Bar", City.Dublin, 11, RouteType.Fastest, TripOption.Insurance, TripOption.AudioGuide),
                new TripRequest(5, "Phoenix Park", "Sandymount", City.Dublin, 9, RouteType.Budget),
                new TripRequest(6, "Trinity College", "Grand Canal Dock", City.Dublin, 2.5, RouteType.Scenic),
                new TripRequest(7, "Cais do Sodré", "Parque das Nações", City.Lisbon, 6, RouteType.Eco),
                new TripRequest(8, "Phoenix Park", "Sandymount", City.Dublin, 9, RouteType.Eco)
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
