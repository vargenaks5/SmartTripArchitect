namespace SmartTripArchitect
{
    public class BudgetRouteStrategy : ITripRouteStrategy
    {
        public string Name => "Бюджетний маршрут (громадський транспорт)";

        public RouteEstimate Estimate(TripRequest request)
        {
            int tickets = request.DistanceKm > 10 ? 2 : 1;
            double duration = 0;
            double cost = 0;
            if (request.City == City.Lisbon)
            {
                duration = request.DistanceKm / 20 * 60 + 8;
                cost = 1.80 * tickets;
            }
            else if (request.City == City.Dublin)
            {
                duration = request.DistanceKm / 18 * 60 + 8;
                cost = 2.00 * tickets;
            }
            return new RouteEstimate(duration, cost, 40 * request.DistanceKm);
        }
    }
}
