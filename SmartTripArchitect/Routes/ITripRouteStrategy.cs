using SmartTripArchitect.Cities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartTripArchitect.Routes
{
    public interface ITripRouteStrategy
    {
        string Name { get; }
        RouteEstimate Estimate(TripRequest request, CityTariffs tariffs);
    }
}
