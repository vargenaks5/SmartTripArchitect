using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartTripArchitect.Routes
{
    public class FastestRoute
    {
        public string Name => "Найшвидший маршрут (таксі)";

        public RouteEstimate Estimate(TripRequest request)
        {
            double duration = 0;
            double cost = 0;
            if (request.City == City.Lisbon)
            {
                duration = request.DistanceKm / 25 * 60 + 5;
                cost = 3.25 + 0.47 * request.DistanceKm;
            }
            else if (request.City == City.Dublin)
            {
                duration = request.DistanceKm / 22 * 60 + 5;
                cost = 4.20 + 1.30 * request.DistanceKm;
            }
            return new RouteEstimate(duration, cost, 120 * request.DistanceKm);
        }
    }
}
