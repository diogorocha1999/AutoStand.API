using AutoStand.BAL.Interfaces;
using AutoStand.BAL.Services;
using AutoStand.BOL.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace AutoStand.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomersController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Customer>> GetAll()
        {
            return Ok(_customerService.GetAllCustomers());
        }

        [HttpGet("{id}")]
        public ActionResult<Customer> Get(int id)
        {
            var customer = _customerService.GetCustomer(id);
            if (customer == null) return NotFound();
            return Ok(customer);
        }

        [HttpGet("bynif/{nif}")]
        public ActionResult<Customer> GetByNIF(string nif)
        {
            var customer = _customerService.GetCustomerByNIF(nif);
            if (customer == null) return NotFound();
            return Ok(customer);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Customer customer)
        {
            try
            {
                _customerService.AddCustomer(customer);
                return CreatedAtAction(nameof(Get), new { id = customer.Id }, customer);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Customer customer)
        {
            if (id != customer.Id) return BadRequest("ID mismatch");

            try
            {
                _customerService.UpdateCustomer(customer);
                return NoContent();
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _customerService.DeleteCustomer(id);
            return NoContent();
        }
    }
}