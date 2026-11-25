using SmartTripArchitect;

namespace SmartTripArchitect.Tests
{
    [TestClass]
    public class TripPlannerTests
    {
        private TripPlanner planner;

        [TestInitialize]
        public void Setup()
        {
            planner = new TripPlanner(new Dictionary<RouteType, ITripRouteStrategy>
            {
                [RouteType.Fastest] = new FastestRouteStrategy(),
                [RouteType.Scenic] = new ScenicRouteStrategy(),
                [RouteType.Budget] = new BudgetRouteStrategy(),
                [RouteType.Eco] = new EcoRouteStrategy()
            });
        }

        // Контрольні приклади з розділів 1, 3 та 4 пояснювальної записки
        private static TripRequest ControlRequest(int id)
        {
            return id switch
            {
                1 => TestData.Request(City.Lisbon, 10, RouteType.Fastest),
                2 => TestData.Request(City.Lisbon, 12, RouteType.Budget, TripOption.Insurance),
                3 => TestData.Request(City.Lisbon, 5, RouteType.Scenic, TripOption.AudioGuide),
                4 => TestData.Request(City.Dublin, 11, RouteType.Fastest, TripOption.Insurance, TripOption.AudioGuide),
                5 => TestData.Request(City.Dublin, 9, RouteType.Budget),
                6 => TestData.Request(City.Dublin, 2.5, RouteType.Scenic),
                7 => TestData.Request(City.Lisbon, 6, RouteType.Eco),
                8 => TestData.Request(City.Dublin, 9, RouteType.Eco),
                9 => TestData.Request(City.Lisbon, 12, RouteType.Budget, TripOption.Insurance, TripOption.LuggageStorage),
                _ => throw new ArgumentOutOfRangeException(nameof(id))
            };
        }

        [DataTestMethod]
        [DataRow(1, 29.0, 7.95)]
        [DataRow(2, 44.0, 6.60)]
        [DataRow(3, 104.0, 8.00)]
        [DataRow(4, 35.0, 31.50)]
        [DataRow(5, 38.0, 2.00)]
        [DataRow(6, 62.0, 0.00)]
        [DataRow(7, 24.0, 4.40)]
        [DataRow(8, 36.0, 2.80)]
        [DataRow(9, 59.0, 12.60)]
        public void Plan_ControlExamples_MatchExpectedValues(int id, double expectedMinutes, double expectedCost)
        {
            TripReport report = planner.Plan(ControlRequest(id));

            Assert.AreEqual(expectedMinutes, report.DurationMinutes, 0.001);
            Assert.AreEqual(expectedCost, report.Cost, 0.001);
        }

        [TestMethod]
        public void Plan_RouteTypeWithoutStrategy_ThrowsArgumentException()
        {
            var fastestOnly = new TripPlanner(new Dictionary<RouteType, ITripRouteStrategy>
            {
                [RouteType.Fastest] = new FastestRouteStrategy()
            });

            Assert.ThrowsException<ArgumentException>(
                () => fastestOnly.Plan(TestData.Request(City.Lisbon, 5, RouteType.Budget)));
        }
    }
}
