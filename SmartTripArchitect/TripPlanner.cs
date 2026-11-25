using SmartTripArchitect.Cities;
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

            CityTariffs tariffs = CityTariffs.For(request.City);
            ITripComponent trip = new BaseTrip(request, routeStrategy, tariffs);

            foreach (TripOption option in request.Options)
                trip = AddOption(trip, option, tariffs);

            string routeTitle = $"{request.StartPoint} → {request.Destination} ({request.City})";
            return new TripReport(request.Id, routeTitle, trip.Description,
                trip.DurationMinutes, trip.Cost, trip.Co2Grams);
        }

        private static ITripComponent AddOption(ITripComponent trip, TripOption option, CityTariffs tariffs)
        {
            switch (option)
            {
                case TripOption.Insurance:
                    return new InsuranceDecorator(trip);
                case TripOption.AudioGuide:
                    return new AudioGuideDecorator(trip, tariffs.AudioGuidePrice);
                case TripOption.LuggageStorage:
                    return new LuggageStorageDecorator(trip, tariffs.LuggageStoragePrice);
                default:
                    throw new ArgumentException("Невідома опція подорожі");
            }
        }
    }
}
