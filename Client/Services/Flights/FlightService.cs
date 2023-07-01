using System.Net.Http.Json;

using FlightManagement.Shared;

using Microsoft.AspNetCore.Components;

namespace FlightManagement.Client.Services.Flights
{
    public class FlightService : IFlightService
    {
        private readonly HttpClient http;
        private readonly NavigationManager navigation;

        public FlightService(HttpClient http, NavigationManager navigation)
        {
            this.http = http;
            this.navigation = navigation;
        }
        public List<Flight> Flights { get; set; } = new List<Flight>();
        public List<Airport> Airports { get; set; } = new List<Airport>();

        public async Task CreateFlight(Flight flight)
        {
            flight.Distance = Distance(flight);

            var result = await http.PostAsJsonAsync("api/flights", flight);
            if (result.IsSuccessStatusCode)
            {
                await SetFlight();
            }

        }

        static int Distance(Flight flight)
        {
            double lat1 = flight.Departure.LatitudeDegree + flight.Departure.LatitudeMinute / 60 + flight.Departure.LatitudeSecond / 60 * 60;
            double lat2 = flight.Destination.LatitudeDegree + flight.Destination.LatitudeMinute / 60 + flight.Destination.LatitudeSecond / 60 * 60;
            double lon1 = flight.Departure.LongitudeDegree + flight.Departure.LongitudeMinute / 60 + flight.Departure.LongitudeSecond / 60 * 60;
            double lon2 = flight.Destination.LongitudeDegree + flight.Destination.LongitudeMinute / 60 + flight.Destination.LongitudeSecond / 60 * 60;
            return Distance(lat1, lat2, lon1, lon2);
        }

        static double DegreeToRadians(double angleInDegree)
        {
            return (angleInDegree * Math.PI) / 180;
        }
        static double MinuteToRadians(double angleInMinute)
        {
            return (angleInMinute * Math.PI) / 180 * 60;
        }
        static double SecondToRadians(double angleInSecond)
        {
            return (angleInSecond * Math.PI) / 180 * 60 * 60;
        }
        static int Distance(double latitude1, double latitude2, double longitude1, double longitude2)
        {
            double EarthRadiusInKm = 6371;

            longitude1 = DegreeToRadians(longitude1);
            longitude2 = DegreeToRadians(longitude2);
            latitude1 = DegreeToRadians(latitude1);
            latitude2 = DegreeToRadians(latitude2);

            /* haversine formula  */
            double deltaLongitude = longitude2 - longitude1;

            double deltaLatitude = latitude2 - latitude1;

            double result = Math.Pow(Math.Sin(deltaLatitude / 2), 2) +
                       Math.Cos(latitude1) * Math.Cos(latitude2) *
                       Math.Pow(Math.Sin(deltaLongitude / 2), 2);

            result = 2 * Math.Asin(Math.Sqrt(result));


            return (int)(result * EarthRadiusInKm);
        }

        private async Task SetFlight()
        {
            navigation.NavigateTo("flights");
        }

        public async Task DeleteFlight(int id)
        {
            var result = await http.DeleteAsync($"api/flights/{id}");
            if (result.IsSuccessStatusCode)
            {
                await SetFlight();
            }
        }

        public async Task GetAirports()
        {
            /*
             * this should be coming from elsewhere as we are not persisting
               airports, for example from external Rest Api
            */
            var result = await http.GetFromJsonAsync<List<Airport>>("api/flights/airports");

            if (result is not null)
            {
                Airports = result;
            }
        }

        public async Task<Flight> GetFlightBy(int id)
        {
            var result = await http.GetFromJsonAsync<Flight>($"api/flights/{id}");
            if (result is not null)
            {
                return result;
            }
            throw new Exception("Flight not found!");
        }

        public async Task GetFlights()
        {
            var result = await http.GetFromJsonAsync<List<Flight>>("api/flights");
            if (result is not null)
            {
                Flights = result;
            }
        }

        public async Task UpdateFlight(int id, Flight flight)
        {
            flight.Distance = Distance(flight);

            var result = await http.PutAsJsonAsync($"api/flights/{id}", flight);
            if (result.IsSuccessStatusCode)
            {
                await SetFlight();
            }
        }
    }
}
