using SmartTripArchitect.Cities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartTripArchitect.Routes
{
    public class EcoRouteStrategy : ITripRouteStrategy
    {
        private const double BikeSpeedKmh = 15;

        public string Name => "Екологічний маршрут (велопрокат)";

        public RouteEstimate Estimate(TripRequest request, CityTariffs tariffs)
        {
            double duration = request.DistanceKm / BikeSpeedKmh * 60;
            double cost = tariffs.BikeUnlockFee + tariffs.BikePricePerMinute * duration;
            return new RouteEstimate(duration, cost, 0);
        }
    }
}
