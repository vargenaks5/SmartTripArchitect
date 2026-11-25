namespace SmartTripArchitect
{
    public interface ITripRouteStrategy
    {
        string Name { get; }
        RouteEstimate Estimate(TripRequest request, CityTariffs tariffs);
    }
}
