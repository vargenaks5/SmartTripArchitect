using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartTripArchitect
{
    public class RouteEstimate
    {
        public double DurationMinutes { get; }
        public double Cost { get; }
        public double Co2Grams { get; }

        public RouteEstimate(double durationMinutes, double cost, double co2Grams)
        {
            DurationMinutes = durationMinutes;
            Cost = cost;
            Co2Grams = co2Grams;
        }
    }
}
