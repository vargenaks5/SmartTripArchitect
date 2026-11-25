namespace SmartTripArchitect
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
