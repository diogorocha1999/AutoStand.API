using AutoStand.BAL.Interfaces;
using AutoStand.BOL.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace AutoStand.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryController : ControllerBase
    {
        private readonly IInventoryService _inventoryService;

        public InventoryController(IInventoryService inventoryService)
        {
            _inventoryService = inventoryService;
        }

        [HttpGet("history")]
        public ActionResult<IEnumerable<InventoryMovement>> GetHistory()
        {
            return Ok(_inventoryService.GetInventoryHistory());
        }

        [HttpGet("current")]
        public ActionResult<IEnumerable<Vehicle>> GetCurrent()
        {
            return Ok(_inventoryService.GetAvailableVehicles());
        }

        [HttpGet("value")]
        public ActionResult<decimal> GetTotalValue()
        {
            return Ok(_inventoryService.GetTotalInventoryValue());
        }

        [HttpPost("add")]
        public IActionResult AddVehicle([FromBody] Vehicle vehicle,
                                      [FromQuery] decimal purchasePrice,
                                      [FromQuery] string supplier)
        {
            try
            {
                _inventoryService.AddVehicleToInventory(vehicle, purchasePrice, supplier);
                return CreatedAtAction(nameof(GetCurrent), vehicle);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("remove/{vehicleId}")]
        public IActionResult RemoveVehicle(int vehicleId, [FromQuery] string reason)
        {
            try
            {
                _inventoryService.RemoveVehicleFromInventory(vehicleId, reason);
                return NoContent();
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}