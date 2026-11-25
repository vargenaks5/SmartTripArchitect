namespace SmartTripArchitect
{
    public class BaseTrip : ITripComponent
    {
        private readonly string routeName;
        private readonly RouteEstimate estimate;

        public BaseTrip(TripRequest request, ITripRouteStrategy routeStrategy, CityTariffs tariffs)
        {
            routeName = routeStrategy.Name;
            estimate = routeStrategy.Estimate(request, tariffs);
        }

        public string Description => routeName;
        public double DurationMinutes => estimate.DurationMinutes;
        public double Cost => estimate.Cost;
        public double Co2Grams => estimate.Co2Grams;
    }
}
