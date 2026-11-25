namespace SmartTripArchitect
{
    public class EcoRouteStrategy : ITripRouteStrategy
    {
        private const double BikeSpeedKmh = 15;

        public string Name => "Екологічний маршрут (велопрокат)";

        public RouteEstimate Estimate(TripRequest request)
        {
            double duration = request.DistanceKm / BikeSpeedKmh * 60;
            double cost = 0;
            if (request.City == City.Lisbon)
                cost = 2.00 + 0.10 * duration;
            else if (request.City == City.Dublin)
                cost = 1.00 + 0.05 * duration;
            return new RouteEstimate(duration, cost, 0);
        }
    }
}
