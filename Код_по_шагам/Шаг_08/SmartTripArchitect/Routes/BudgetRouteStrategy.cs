namespace SmartTripArchitect
{
    public class BudgetRouteStrategy : ITripRouteStrategy
    {
        private const double WaitingMinutes = 8;
        private const double TransferDistanceKm = 10;
        private const double Co2GramsPerKm = 40;

        public string Name => "Бюджетний маршрут (громадський транспорт)";

        public RouteEstimate Estimate(TripRequest request, CityTariffs tariffs)
        {
            int tickets = request.DistanceKm > TransferDistanceKm ? 2 : 1;
            double duration = request.DistanceKm / tariffs.TransitSpeedKmh * 60 + WaitingMinutes;
            double cost = tariffs.TransitTicketPrice * tickets;
            return new RouteEstimate(duration, cost, Co2GramsPerKm * request.DistanceKm);
        }
    }
}
