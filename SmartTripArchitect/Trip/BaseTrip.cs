using SmartTripArchitect.Routes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartTripArchitect.Trip
{
    public class BaseTrip : ITripComponent
    {
        private readonly string routeName;
        private readonly RouteEstimate estimate;

        public BaseTrip(TripRequest request, ITripRouteStrategy routeStrategy)
        {
            routeName = routeStrategy.Name;
            estimate = routeStrategy.Estimate(request);
        }

        public string Description => routeName;
        public double DurationMinutes => estimate.DurationMinutes;
        public double Cost => estimate.Cost;
        public double Co2Grams => estimate.Co2Grams;
    }
}
