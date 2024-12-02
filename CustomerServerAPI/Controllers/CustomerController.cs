using CustomerServerAPI.Interfaces;
using CustomerServerAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace CustomerServerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet("sss")]
        public ActionResult Get()
        {
            return Ok("GOOD");
        }

        [HttpGet("customers")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _customerService.GetAll();
            if (result == null || !result.Any())
            {
                return NoContent();
            }

            return Ok(result);
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetById(int id)
        {
            var customer = await _customerService.GetById(id);
            return customer == null ? NoContent() : Ok(customer);
        }

        [HttpPost("add")]
        public async Task<IActionResult> Insert([FromBody] Customer customer)
        {
            if (customer == null)
            {
                BadRequest();
            }

            var result = await _customerService.InsertCustomer(customer);
            return Ok(result);
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update([FromBody] Customer customer)
        {
            if (customer == null)
            {
                BadRequest();
            }

            var result = await _customerService.UpdateCustomer(customer);

            return result == null ? NoContent() : Ok(result);
        }

        [HttpDelete("delete/{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            await _customerService.DeleteById(id);
            return Ok();
        }
    }
}
