using AutoStand.BAL.Interfaces;
using AutoStand.BAL.Services;
using AutoStand.BOL.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace AutoStand.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesController : ControllerBase
    {
        private readonly ISaleService _saleService;

        public SalesController(ISaleService saleService)
        {
            _saleService = saleService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Sale>> GetAll()
        {
            return Ok(_saleService.GetAllSales());
        }

        [HttpGet("{id}")]
        public ActionResult<Sale> Get(int id)
        {
            var sale = _saleService.GetSale(id);
            if (sale == null) return NotFound();
            return Ok(sale);
        }

        [HttpGet("bydate")]
        public ActionResult<IEnumerable<Sale>> GetByDateRange([FromQuery] DateTime startDate, [FromQuery] DateTime endDate)
        {
            return Ok(_saleService.GetSalesByDateRange(startDate, endDate));
        }

        [HttpPost]
        public IActionResult Post([FromBody] Sale sale)
        {
            try
            {
                _saleService.RegisterSale(sale);
                return CreatedAtAction(nameof(Get), new { id = sale.Id }, sale);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Cancel(int id)
        {
            try
            {
                _saleService.CancelSale(id);
                return NoContent();
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}