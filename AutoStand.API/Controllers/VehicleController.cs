using AutoStand.BAL.Interfaces;
using AutoStand.BAL.Services;
using AutoStand.BOL.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace AutoStand.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehiclesController : ControllerBase
    {
        private readonly IVehicleService _vehicleService;

        public VehiclesController(IVehicleService vehicleService)
        {
            _vehicleService = vehicleService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Vehicle>> GetAll()
        {
            return Ok(_vehicleService.GetAllVehicles());
        }

        [HttpGet("{id}")]
        public ActionResult<Vehicle> Get(int id)
        {
            var vehicle = _vehicleService.GetVehicle(id);
            if (vehicle == null) return NotFound();
            return Ok(vehicle);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Vehicle vehicle)
        {
            _vehicleService.AddVehicle(vehicle);
            return CreatedAtAction(nameof(Get), new { id = vehicle.Id }, vehicle);
        }
    }
}