using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartTripArchitect.Cities
{
    public class CityTariffs
    {
        private static readonly Dictionary<City, CityTariffs> All = new Dictionary<City, CityTariffs>
        {
            [City.Lisbon] = new CityTariffs
            {
                TaxiStartFare = 3.25,
                TaxiPricePerKm = 0.47,
                TaxiSpeedKmh = 25,
                TransitTicketPrice = 1.80,
                TransitSpeedKmh = 20,
                BikeUnlockFee = 2.00,
                BikePricePerMinute = 0.10,
                AudioGuidePrice = 8.00,
                LuggageStoragePrice = 6.00
            },
            [City.Dublin] = new CityTariffs
            {
                TaxiStartFare = 4.20,
                TaxiPricePerKm = 1.30,
                TaxiSpeedKmh = 22,
                TransitTicketPrice = 2.00,
                TransitSpeedKmh = 18,
                BikeUnlockFee = 1.00,
                BikePricePerMinute = 0.05,
                AudioGuidePrice = 10.00,
                LuggageStoragePrice = 7.00
            }
        };

        public double TaxiStartFare { get; set; }
        public double TaxiPricePerKm { get; set; }
        public double TaxiSpeedKmh { get; set; }
        public double TransitTicketPrice { get; set; }
        public double TransitSpeedKmh { get; set; }
        public double BikeUnlockFee { get; set; }
        public double BikePricePerMinute { get; set; }
        public double AudioGuidePrice { get; set; }
        public double LuggageStoragePrice { get; set; }

        public static CityTariffs For(City city)
        {
            if (!All.TryGetValue(city, out CityTariffs tariffs))
                throw new NotSupportedException($"Для міста {city} не задано тарифи");
            return tariffs;
        }
    }
}
