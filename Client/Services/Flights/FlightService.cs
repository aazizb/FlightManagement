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
            await http.PostAsJsonAsync("api/flights", flight);

            await SetFlight();
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
            var result = await http.PutAsJsonAsync($"api/flights/{id}", flight);
            if (result.IsSuccessStatusCode)
            {
                await SetFlight();
            }
        }
    }
}
