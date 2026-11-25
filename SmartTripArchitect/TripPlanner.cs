using SmartTripArchitect.Routes;
using SmartTripArchitect.Trip;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            ITripComponent trip = new BaseTrip(request, routeStrategy);

            foreach (TripOption option in request.Options)
                trip = AddOption(trip, option, request.City);

            string routeTitle = $"{request.StartPoint} → {request.Destination} ({request.City})";
            return new TripReport(request.Id, routeTitle, trip.Description,
                trip.DurationMinutes, trip.Cost, trip.Co2Grams);
        }

        private static ITripComponent AddOption(ITripComponent trip, TripOption option, City city)
        {
            switch (option)
            {
                case TripOption.Insurance:
                    return new InsuranceDecorator(trip);
                case TripOption.AudioGuide:
                    return new AudioGuideDecorator(trip, city);
                case TripOption.LuggageStorage:
                    return new LuggageStorageDecorator(trip, city);
                default:
                    throw new ArgumentException("Невідома опція подорожі");
            }
        }
    }
}
