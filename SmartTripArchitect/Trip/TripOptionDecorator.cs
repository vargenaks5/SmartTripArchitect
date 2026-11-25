using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartTripArchitect.Trip
{
    public abstract class TripOptionDecorator : ITripComponent
    {
        protected ITripComponent Inner { get; }

        protected TripOptionDecorator(ITripComponent inner)
        {
            Inner = inner;
        }

        public virtual string Description => Inner.Description;
        public virtual double DurationMinutes => Inner.DurationMinutes;
        public virtual double Cost => Inner.Cost;
        public virtual double Co2Grams => Inner.Co2Grams;
    }
}
