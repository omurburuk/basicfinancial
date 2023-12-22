using AutoMapper;
using BasicFinancial.Controllers.Mobile;
using BasicFinancial.Core.Models;
using BasicFinancial.Core.Services;
using BasicFinancial.DTO;
using BasicFinancial.Validators;
using Microsoft.AspNetCore.Mvc;

namespace BasicFinancial.Controllers
{
    [Route("api/mobile/v1/[controller]")]
    [ApiController]
    [Helper.Authorize]
    public class CustomerController : MainController
    {
        private readonly ICustomerService _customerService;
        private readonly IMapper _mapper;

        public CustomerController(ICustomerService customerService, IMapper mapper)
        {
            this._mapper = mapper;
            this._customerService = customerService;
        }

        [HttpGet("")]
        public async Task<ActionResult<IEnumerable<CustomerDTO>>> GetAllCustomers()
        {
            var customers = await _customerService.GetAllCustomers();
            var customerResources = _mapper.Map<IEnumerable<Customer>, IEnumerable<CustomerDTO>>(customers);

            return Ok(customerResources);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerDTO>> GetCustomerById(int id)
        {
            var customer = await _customerService.GetCustomerById(id);
            var customerResource = _mapper.Map<Customer, CustomerDTO>(customer);

            return Ok(customerResource);
        }

        [HttpPost("")]
        public async Task<ActionResult<CustomerDTO>> CreateCustomer([FromBody] SaveCustomerDTO saveCustomerResource)
        {
            var validator = new SaveCustomerResourceValidator();
            var validationResult = await validator.ValidateAsync(saveCustomerResource);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors); // this needs refining, but for demo it is ok

            var customerToCreate = _mapper.Map<SaveCustomerDTO, Customer>(saveCustomerResource);

            var newCustomer = await _customerService.CreateCustomer(customerToCreate);

            var customer = await _customerService.GetCustomerById(newCustomer.Id);

            var customerResource = _mapper.Map<Customer, CustomerDTO>(customer);

            return Ok(customerResource);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<CustomerDTO>> UpdateCustomer(int id, [FromBody] SaveCustomerDTO saveCustomerResource)
        {
            var validator = new SaveCustomerResourceValidator();
            var validationResult = await validator.ValidateAsync(saveCustomerResource);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors); // this needs refining, but for demo it is ok

            var customerToBeUpdated = await _customerService.GetCustomerById(id);

            if (customerToBeUpdated == null)
                return NotFound();

            var customer = _mapper.Map<SaveCustomerDTO, Customer>(saveCustomerResource);

            await _customerService.UpdateCustomer(customerToBeUpdated, customer);

            var updatedCustomer = await _customerService.GetCustomerById(id);

            var updatedCustomerResource = _mapper.Map<Customer, CustomerDTO>(updatedCustomer);

            return Ok(updatedCustomerResource);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            var customer = await _customerService.GetCustomerById(id);

            await _customerService.DeleteCustomer(customer);

            return NoContent();
        }
    }
}
