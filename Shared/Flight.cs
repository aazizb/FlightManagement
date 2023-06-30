namespace FlightManagement.Shared
{
    public class Flight
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Airport Departure { get; set; }
        public int DepartureAirportId { get; set; }
        public Airport Destination { get; set; }
        public int DestinationAirportId { get; set; }
        public int Distance { get; set; }

    }
}
