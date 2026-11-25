using SmartTripArchitect.Cities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartTripArchitect.Routes
{
    public class ScenicRouteStrategy : ITripRouteStrategy
    {
        private const double DetourFactor = 1.4;
        private const double WalkingSpeedKmh = 5;
        private const double PhotoStopsMinutes = 20;

        public string Name => "Мальовничий маршрут (пішки через парки та набережні)";

        public RouteEstimate Estimate(TripRequest request, CityTariffs tariffs)
        {
            double walkKm = request.DistanceKm * DetourFactor;
            double duration = walkKm / WalkingSpeedKmh * 60 + PhotoStopsMinutes;
            return new RouteEstimate(duration, 0, 0);
        }
    }
}
