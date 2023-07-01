using FlightManagement.Server.Services.Contracts;
using FlightManagement.Shared;

using Microsoft.AspNetCore.Mvc;

namespace FlightManagement.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlightsController : ControllerBase
    {
        private readonly IServiceManager service;

        public FlightsController(IServiceManager service)
        {
            this.service = service;
        }
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var flights = service.FlightService.GetFlightAirports(false);
                return Ok(flights);
            }
            catch (Exception ex)
            {

                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet("{id:int}", Name = "GetBy")]
        public IActionResult GetBy(int id)
        {
            Flight flight = service.FlightService.GetFlightBy(id, false);
            if (flight == null)
            {
                return NotFound();
            }
            return Ok(flight);
        }
        [HttpPost]
        public IActionResult Create([FromBody] Flight flight)
        {
            if (flight is null)
            {
                return BadRequest();
            }
            var entity = service.FlightService.CreateFlight(flight);
            return CreatedAtRoute("GetBy", new { id = entity.Id }, entity);
        }
        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            service.FlightService.DeleteFlight(id, false);
            return NoContent();
        }
        [HttpPut("{id:int}")]
        public IActionResult Update(int id, [FromBody] Flight flight)
        {
            if (flight == null)
            {
                return BadRequest();
            }
            service.FlightService.UpdateFlight(id, flight);
            return NoContent();
        }
        [HttpGet("airports")]
        public IActionResult GetAirports()
        {
            try
            {
                var airports = service.AirportService.GetAll(false);
                return Ok(airports);

            }
            catch (Exception ex)
            {

                return StatusCode(500, ex.Message);
            }
        }

    }
}
