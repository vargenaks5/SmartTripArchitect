using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartTripArchitect
{
    public class TripRequest
    {
        public int Id { get; set; }
        public string StartPoint { get; set; }
        public string Destination { get; set; }
        public City City { get; set; }
        public double DistanceKm { get; set; }
        public RouteType RouteType { get; set; }
        public List<TripOption> Options { get; }

        public TripRequest(int id, string startPoint, string destination, City city,
            double distanceKm, RouteType routeType, params TripOption[] options)
        {
            Id = id;
            StartPoint = startPoint;
            Destination = destination;
            City = city;
            DistanceKm = distanceKm;
            RouteType = routeType;
            Options = new List<TripOption>(options);
        }
    }
}
