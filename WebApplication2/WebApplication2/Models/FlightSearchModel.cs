namespace WebApplication2.Models
{
    public class FlightSearchModel
    {
        public DateTime DepartureDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public string DepartureCity { get; set; }
        public string DestinationCity { get; set; }
        public int PassengerCount { get; set; }
        public bool RoundTrip { get; set; }
    }
    public class SearchRequest
    {
        public string Origin { get; set; }
        public string Destination { get; set; }
        public DateTime DepartureDate { get; set; }
        public DateTime ReturnDate { get; set; }
    }
}
