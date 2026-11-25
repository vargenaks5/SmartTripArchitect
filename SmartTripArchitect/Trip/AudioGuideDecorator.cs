using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartTripArchitect.Trip
{
    public class AudioGuideDecorator : TripOptionDecorator
    {
        private readonly double price;

        public AudioGuideDecorator(ITripComponent inner, double price) : base(inner)
        {
            this.price = price;
        }

        public override string Description => Inner.Description + " + аудіогід";
        public override double Cost => Inner.Cost + price;
    }
}
