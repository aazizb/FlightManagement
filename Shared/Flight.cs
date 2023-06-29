namespace FlightManagement.Shared
{
    public class Flight
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Departure { get; set; }
        public required string Destination { get; set; }
        public int Distance { get; set; }

        public Airport? Airport { get; set; }
        public int AirportId { get; set; }
    }
}
