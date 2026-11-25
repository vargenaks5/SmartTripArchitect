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
            double duration = 0;
            double cost = 0;
            double co2 = 0;
            string description = "";

            if (request.RouteType == RouteType.Fastest)
            {
                description = "Найшвидший маршрут (таксі)";
                if (request.City == City.Lisbon)
                {
                    duration = request.DistanceKm / 25 * 60 + 5;
                    cost = 3.25 + 0.47 * request.DistanceKm;
                }
                else if (request.City == City.Dublin)
                {
                    duration = request.DistanceKm / 22 * 60 + 5;
                    cost = 4.20 + 1.30 * request.DistanceKm;
                }
                co2 = 120 * request.DistanceKm;
            }
            else if (request.RouteType == RouteType.Scenic)
            {
                description = "Мальовничий маршрут (пішки через парки та набережні)";
                double walkKm = request.DistanceKm * 1.4;
                duration = walkKm / 5 * 60 + 20;
                cost = 0;
                co2 = 0;
            }
            else if (request.RouteType == RouteType.Budget)
            {
                description = "Бюджетний маршрут (громадський транспорт)";
                int tickets = request.DistanceKm > 10 ? 2 : 1;
                if (request.City == City.Lisbon)
                {
                    duration = request.DistanceKm / 20 * 60 + 8;
                    cost = 1.80 * tickets;
                }
                else if (request.City == City.Dublin)
                {
                    duration = request.DistanceKm / 18 * 60 + 8;
                    cost = 2.00 * tickets;
                }
                co2 = 40 * request.DistanceKm;
            }

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

            string route = $"{request.StartPoint} → {request.Destination} ({request.City})";
            return new TripReport(request.Id, route, description, duration, cost, co2);
        }
    }
}
