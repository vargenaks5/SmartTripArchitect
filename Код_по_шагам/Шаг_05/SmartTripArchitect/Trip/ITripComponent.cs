namespace SmartTripArchitect
{
    public interface ITripComponent
    {
        string Description { get; }
        double DurationMinutes { get; }
        double Cost { get; }
        double Co2Grams { get; }
    }
}
