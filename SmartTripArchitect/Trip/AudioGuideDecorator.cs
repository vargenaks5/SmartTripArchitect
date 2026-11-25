using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartTripArchitect.Trip
{
    public class AudioGuideDecorator : TripOptionDecorator
    {
        private readonly City city;

        public AudioGuideDecorator(ITripComponent inner, City city) : base(inner)
        {
            this.city = city;
        }

        public override string Description => Inner.Description + " + аудіогід";

        public override double Cost
        {
            get
            {
                double price = 0;
                if (city == City.Lisbon)
                    price = 8.00;
                else if (city == City.Dublin)
                    price = 10.00;
                return Inner.Cost + price;
            }
        }
    }
}
