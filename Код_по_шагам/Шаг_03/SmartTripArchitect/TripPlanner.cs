namespace SmartTripArchitect
{
    public class TripPlanner
    {
        private readonly IReadOnlyDictionary<RouteType, ITripRouteStrategy> routeStrategies;

        public TripPlanner(IReadOnlyDictionary<RouteType, ITripRouteStrategy> routeStrategies)
        {
            this.routeStrategies = routeStrategies;
        }

        public TripReport Plan(TripRequest request)
        {
            if (!routeStrategies.TryGetValue(request.RouteType, out ITripRouteStrategy routeStrategy))
                throw new ArgumentException("Невідомий тип маршруту");

            RouteEstimate estimate = routeStrategy.Estimate(request);
            string description = routeStrategy.Name;
            double cost = estimate.Cost;

            if (request.WithInsurance)
            {
                cost += 3.00;
                description += " + страховка";
            }
            if (request.WithAudioGuide)
            {
                if (request.City == City.Lisbon)
                    cost += 8.00;
                else if (request.City == City.Dublin)
                    cost += 10.00;
                description += " + аудіогід";
            }

            string routeTitle = $"{request.StartPoint} → {request.Destination} ({request.City})";
            return new TripReport(request.Id, routeTitle, description,
                estimate.DurationMinutes, cost, estimate.Co2Grams);
        }
    }
}
