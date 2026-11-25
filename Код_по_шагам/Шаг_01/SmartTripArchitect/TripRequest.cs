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
        public bool WithInsurance { get; set; }
        public bool WithAudioGuide { get; set; }

        public TripRequest(int id, string startPoint, string destination, City city,
            double distanceKm, RouteType routeType, bool withInsurance, bool withAudioGuide)
        {
            Id = id;
            StartPoint = startPoint;
            Destination = destination;
            City = city;
            DistanceKm = distanceKm;
            RouteType = routeType;
            WithInsurance = withInsurance;
            WithAudioGuide = withAudioGuide;
        }
    }
}
