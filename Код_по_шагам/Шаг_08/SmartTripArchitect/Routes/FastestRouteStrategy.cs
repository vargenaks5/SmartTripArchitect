namespace SmartTripArchitect
{
    public class FastestRouteStrategy : ITripRouteStrategy
    {
        private const double WaitingMinutes = 5;
        private const double Co2GramsPerKm = 120;

        public string Name => "Найшвидший маршрут (таксі)";

        public RouteEstimate Estimate(TripRequest request, CityTariffs tariffs)
        {
            double duration = request.DistanceKm / tariffs.TaxiSpeedKmh * 60 + WaitingMinutes;
            double cost = tariffs.TaxiStartFare + tariffs.TaxiPricePerKm * request.DistanceKm;
            return new RouteEstimate(duration, cost, Co2GramsPerKm * request.DistanceKm);
        }
    }
}
