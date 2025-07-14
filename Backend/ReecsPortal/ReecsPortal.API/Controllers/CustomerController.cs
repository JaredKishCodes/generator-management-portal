using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReecsPortal.Application.Customer.Commands;
using ReecsPortal.Application.Customer.Queries;
using ReecsPortal.Application.DTOs.Customer;

namespace ReecsPortal.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController(ISender sender) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<CustResponse>> GetAllCustomers()
        {
            var response = new GetAllCustomersQuery();

            return Ok(await sender.Send(response));
        }

        [HttpGet("{custCode:int}")]
        public async Task<ActionResult<CustResponse>> GetCustomerById(int custCode)
        {
            var response = new GetCustomerByIdQuery(custCode);
            
            var customer = await sender.Send(response);
            if (customer == null)
            {
                return NotFound($"Customer with ID {custCode} not found.");
            }
            return Ok(customer);
        }

        [HttpPost]
        public async Task<ActionResult<CustResponse>> CreateCustomer([FromBody] CustRequest customerRequest)
        {
            if (customerRequest == null)
            {
                return BadRequest("Customer request cannot be null");
            }
            var command = new CreateCustomerCommand(customerRequest);
            var createdCustomer = await sender.Send(command);
            return CreatedAtAction(nameof(GetCustomerById), new { custCode = createdCustomer.CustCode }, createdCustomer);
        }
        [HttpPut("{custCode:int}")]
        public async Task<ActionResult<CustResponse>> UpdateCustomer(int custCode, [FromBody] CustRequest customerRequest)
        {
            if (customerRequest == null)
            {
                return BadRequest("Customer request cannot be null");
            }
            var command = new UpdateCustomerCommand(custCode, customerRequest);
            var updatedCustomer = await sender.Send(command);
            if (updatedCustomer == null)
            {
                return NotFound($"Customer with ID {custCode} not found.");
            }
            return Ok(updatedCustomer);
        }

        [HttpDelete("{custCode:int}")]
        public async Task<bool> DeleteCustomer(int custCode)
        {
            var command = new DeleteCustomerCommand(custCode);
            var result = await sender.Send(command);
            if (!result)
            {
                return false;
            }
            return true;
        }
    }
}
