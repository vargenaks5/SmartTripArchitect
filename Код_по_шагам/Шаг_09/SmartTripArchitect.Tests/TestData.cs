using SmartTripArchitect;

namespace SmartTripArchitect.Tests
{
    internal static class TestData
    {
        public static readonly CityTariffs LisbonTariffs = new CityTariffs
        {
            TaxiStartFare = 3.25,
            TaxiPricePerKm = 0.47,
            TaxiSpeedKmh = 25,
            TransitTicketPrice = 1.80,
            TransitSpeedKmh = 20,
            BikeUnlockFee = 2.00,
            BikePricePerMinute = 0.10,
            AudioGuidePrice = 8.00,
            LuggageStoragePrice = 6.00
        };

        public static TripRequest Request(City city, double distanceKm, RouteType routeType,
            params TripOption[] options)
        {
            return new TripRequest(1, "A", "B", city, distanceKm, routeType, options);
        }
    }

    // Заглушка стратегії: дозволяє тестувати декоратори окремо від тарифів міст
    internal class FixedRouteStrategy : ITripRouteStrategy
    {
        private readonly RouteEstimate estimate;

        public FixedRouteStrategy(double minutes, double cost, double co2)
        {
            estimate = new RouteEstimate(minutes, cost, co2);
        }

        public string Name => "Тестовий маршрут";

        public RouteEstimate Estimate(TripRequest request, CityTariffs tariffs) => estimate;
    }
}
