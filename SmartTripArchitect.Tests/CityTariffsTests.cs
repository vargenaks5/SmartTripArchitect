using Microsoft.VisualStudio.TestTools.UnitTesting;
using SmartTripArchitect.Cities;
using SmartTripArchitect.Routes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartTripArchitect.Tests
{
    [TestClass]
    public class CityTariffsTests
    {
        [TestMethod]
        public void For_Lisbon_ReturnsLisbonPrices()
        {
            CityTariffs tariffs = CityTariffs.For(City.Lisbon);

            Assert.AreEqual(3.25, tariffs.TaxiStartFare, 0.001);
            Assert.AreEqual(8.00, tariffs.AudioGuidePrice, 0.001);
        }

        [TestMethod]
        public void SameStrategy_WithDifferentCities_GivesDifferentCost()
        {
            var strategy = new FastestRouteStrategy();
            var request = TestData.Request(City.Lisbon, 10, RouteType.Fastest);

            double lisbon = strategy.Estimate(request, CityTariffs.For(City.Lisbon)).Cost;
            double dublin = strategy.Estimate(request, CityTariffs.For(City.Dublin)).Cost;

            Assert.AreEqual(7.95, lisbon, 0.001);
            Assert.AreEqual(17.20, dublin, 0.001);
        }

        [TestMethod]
        public void For_UnknownCity_ThrowsNotSupported()
        {
            Assert.ThrowsException<NotSupportedException>(() => CityTariffs.For((City)99));
        }
    }
}
