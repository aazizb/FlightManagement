namespace FlightManagement.Shared
{
    public class Flight
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Airport? Departure { get; set; }
        public int DepartureId { get; set; }
        public Airport? Destination { get; set; }
        public int DestinationId { get; set; }
        public int Distance { get; set; }

    }
}
