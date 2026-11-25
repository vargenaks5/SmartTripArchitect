using Microsoft.VisualStudio.TestTools.UnitTesting;
using SmartTripArchitect.Routes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartTripArchitect.Tests
{
    [TestClass]
    public class RouteStrategyTests
    {
        private const double Delta = 0.001;

        [TestMethod]
        public void FastestRoute_Lisbon10Km_ReturnsTaxiPriceAndTime()
        {
            var strategy = new FastestRouteStrategy();

            RouteEstimate result = strategy.Estimate(
                TestData.Request(City.Lisbon, 10, RouteType.Fastest), TestData.LisbonTariffs);

            Assert.AreEqual(29, result.DurationMinutes, Delta);
            Assert.AreEqual(7.95, result.Cost, Delta);
            Assert.AreEqual(1200, result.Co2Grams, Delta);
        }

        [TestMethod]
        public void BudgetRoute_LongerThan10Km_NeedsTwoTickets()
        {
            var strategy = new BudgetRouteStrategy();

            RouteEstimate result = strategy.Estimate(
                TestData.Request(City.Lisbon, 12, RouteType.Budget), TestData.LisbonTariffs);

            Assert.AreEqual(44, result.DurationMinutes, Delta);
            Assert.AreEqual(3.60, result.Cost, Delta);
        }

        [TestMethod]
        public void BudgetRoute_ShortTrip_NeedsOneTicket()
        {
            var strategy = new BudgetRouteStrategy();

            RouteEstimate result = strategy.Estimate(
                TestData.Request(City.Lisbon, 8, RouteType.Budget), TestData.LisbonTariffs);

            Assert.AreEqual(1.80, result.Cost, Delta);
        }

        [TestMethod]
        public void ScenicRoute_IsFreeAndHasNoEmissions()
        {
            var strategy = new ScenicRouteStrategy();

            RouteEstimate result = strategy.Estimate(
                TestData.Request(City.Lisbon, 5, RouteType.Scenic), TestData.LisbonTariffs);

            Assert.AreEqual(104, result.DurationMinutes, Delta);
            Assert.AreEqual(0, result.Cost, Delta);
            Assert.AreEqual(0, result.Co2Grams, Delta);
        }

        [TestMethod]
        public void EcoRoute_Lisbon6Km_ReturnsBikeRentalPrice()
        {
            var strategy = new EcoRouteStrategy();

            RouteEstimate result = strategy.Estimate(
                TestData.Request(City.Lisbon, 6, RouteType.Eco), TestData.LisbonTariffs);

            Assert.AreEqual(24, result.DurationMinutes, Delta);
            Assert.AreEqual(4.40, result.Cost, Delta);
            Assert.AreEqual(0, result.Co2Grams, Delta);
        }
    }
}
