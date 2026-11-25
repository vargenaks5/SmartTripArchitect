using SmartTripArchitect.Routes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartTripArchitect
{
    public class TripPlanner
    {
        public TripReport Plan(TripRequest request)
        {
            RouteEstimate estimate;
            string description;

            if (request.RouteType == RouteType.Fastest)
            {
                var route = new FastestRoute();
                estimate = route.Estimate(request);
                description = route.Name;
            }
            else if (request.RouteType == RouteType.Scenic)
            {
                var route = new ScenicRoute();
                estimate = route.Estimate(request);
                description = route.Name;
            }
            else if (request.RouteType == RouteType.Budget)
            {
                var route = new BudgetRoute();
                estimate = route.Estimate(request);
                description = route.Name;
            }
            else
            {
                throw new ArgumentException("Невідомий тип маршруту");
            }

            double cost = estimate.Cost;

            if (request.WithInsurance)
            {
                cost += 3.00;
                description += " + страховка";
            }
            if (request.WithAudioGuide)
            {
                if (request.City == City.Lisbon)
                    cost += 8.00;
                else if (request.City == City.Dublin)
                    cost += 10.00;
                description += " + аудіогід";
            }

            string routeTitle = $"{request.StartPoint} → {request.Destination} ({request.City})";
            return new TripReport(request.Id, routeTitle, description,
                estimate.DurationMinutes, cost, estimate.Co2Grams);
        }
    }
}
