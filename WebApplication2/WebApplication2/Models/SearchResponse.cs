namespace WebApplication2.Models
{
   
    

        public class SearchResponse
        {
            public Body Body { get; set; }
        }

        public class Body
        {
            public Availabilitysearchresponse AvailabilitySearchResponse { get; set; }
        }

        public class Availabilitysearchresponse
        {
            public Availabilitysearchresult AvailabilitySearchResult { get; set; }
        }

        public class Availabilitysearchresult
        {
            public Flightoption[] FlightOptions { get; set; }
            public bool HasError { get; set; }
        }

        public class Flightoption
        {
            public DateTime ArrivalDateTime { get; set; }
            public DateTime DepartureDateTime { get; set; }
            public string FlightNumber { get; set; }
            public float Price { get; set; }
            public float ReturnCode { get; set; }
    }

    
}
