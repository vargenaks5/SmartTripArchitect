namespace SmartTripArchitect
{
    public class ScenicRouteStrategy : ITripRouteStrategy
    {
        public string Name => "Мальовничий маршрут (пішки через парки та набережні)";

        public RouteEstimate Estimate(TripRequest request)
        {
            double walkKm = request.DistanceKm * 1.4;
            double duration = walkKm / 5 * 60 + 20;
            return new RouteEstimate(duration, 0, 0);
        }
    }
}
