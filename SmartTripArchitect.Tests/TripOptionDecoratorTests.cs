using Microsoft.VisualStudio.TestTools.UnitTesting;
using SmartTripArchitect.Trip;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartTripArchitect.Tests
{
    [TestClass]
    public class TripOptionDecoratorTests
    {
        private const double Delta = 0.001;

        private static ITripComponent CreateBaseTrip()
        {
            var request = TestData.Request(City.Lisbon, 10, RouteType.Fastest);
            return new BaseTrip(request, new FixedRouteStrategy(30, 10, 500), TestData.LisbonTariffs);
        }

        [TestMethod]
        public void Insurance_AddsFixedPrice()
        {
            ITripComponent trip = new InsuranceDecorator(CreateBaseTrip());

            Assert.AreEqual(13, trip.Cost, Delta);
            Assert.AreEqual(30, trip.DurationMinutes, Delta);
        }

        [TestMethod]
        public void AudioGuide_AddsGivenPriceAndDescription()
        {
            ITripComponent trip = new AudioGuideDecorator(CreateBaseTrip(), 8);

            Assert.AreEqual(18, trip.Cost, Delta);
            StringAssert.EndsWith(trip.Description, "+ аудіогід");
        }

        [TestMethod]
        public void LuggageStorage_AddsPriceAndDropOffTime()
        {
            ITripComponent trip = new LuggageStorageDecorator(CreateBaseTrip(), 6);

            Assert.AreEqual(16, trip.Cost, Delta);
            Assert.AreEqual(45, trip.DurationMinutes, Delta);
        }

        [TestMethod]
        public void SeveralOptions_AreCombinedInWrappingOrder()
        {
            ITripComponent trip = CreateBaseTrip();
            trip = new InsuranceDecorator(trip);
            trip = new AudioGuideDecorator(trip, 8);
            trip = new LuggageStorageDecorator(trip, 6);

            Assert.AreEqual(27, trip.Cost, Delta);
            Assert.AreEqual(45, trip.DurationMinutes, Delta);
            Assert.AreEqual(500, trip.Co2Grams, Delta);
            Assert.AreEqual("Тестовий маршрут + страховка + аудіогід + камера схову багажу", trip.Description);
        }
    }
}
