namespace SmartTripArchitect
{
    public class LuggageStorageDecorator : TripOptionDecorator
    {
        private const double DropOffMinutes = 15;
        private readonly City city;

        public LuggageStorageDecorator(ITripComponent inner, City city) : base(inner)
        {
            this.city = city;
        }

        public override string Description => Inner.Description + " + камера схову багажу";
        public override double DurationMinutes => Inner.DurationMinutes + DropOffMinutes;

        public override double Cost
        {
            get
            {
                double price = 0;
                if (city == City.Lisbon)
                    price = 6.00;
                else if (city == City.Dublin)
                    price = 7.00;
                return Inner.Cost + price;
            }
        }
    }
}
