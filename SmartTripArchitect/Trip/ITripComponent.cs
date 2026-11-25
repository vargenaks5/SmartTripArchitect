using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartTripArchitect.Trip
{
    public interface ITripComponent
    {
        string Description { get; }
        double DurationMinutes { get; }
        double Cost { get; }
        double Co2Grams { get; }
    }
}
