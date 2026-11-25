using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartTripArchitect.Trip
{
    public class LuggageStorageDecorator : TripOptionDecorator
    {
        private const double DropOffMinutes = 15;
        private readonly double price;

        public LuggageStorageDecorator(ITripComponent inner, double price) : base(inner)
        {
            this.price = price;
        }

        public override string Description => Inner.Description + " + камера схову багажу";
        public override double DurationMinutes => Inner.DurationMinutes + DropOffMinutes;
        public override double Cost => Inner.Cost + price;
    }
}
