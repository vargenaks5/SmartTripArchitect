namespace SmartTripArchitect
{
    public class TripReport
    {
        public int TripId { get; }
        public string Route { get; }
        public string Description { get; }
        public double DurationMinutes { get; }
        public double Cost { get; }
        public double Co2Grams { get; }

        public TripReport(int tripId, string route, string description,
            double durationMinutes, double cost, double co2Grams)
        {
            TripId = tripId;
            Route = route;
            Description = description;
            DurationMinutes = durationMinutes;
            Cost = cost;
            Co2Grams = co2Grams;
        }

        public override string ToString()
        {
            return $"Поїздка #{TripId}: {Route}\n" +
                   $"   {Description}\n" +
                   $"   Час: {DurationMinutes:F0} хв | Вартість: {Cost:F2} EUR | CO2: {Co2Grams:F0} г";
        }
    }
}
