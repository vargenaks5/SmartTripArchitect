using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartTripArchitect.Routes
{
    public class ScenicRoute
    {
        public string Name => "Мальовничий маршрут (пішки через парки та набережні)";

        public RouteEstimate Estimate(TripRequest request)
        {
            double walkKm = request.DistanceKm * 1.4;
            double duration = walkKm / 5 * 60 + 20;
            return new RouteEstimate(duration, 0, 0);
        }
    }
}
