using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartTripArchitect.Trip
{
    public class InsuranceDecorator : TripOptionDecorator
    {
        private const double InsurancePrice = 3.00;

        public InsuranceDecorator(ITripComponent inner) : base(inner)
        {
        }

        public override string Description => Inner.Description + " + страховка";
        public override double Cost => Inner.Cost + InsurancePrice;
    }
}
