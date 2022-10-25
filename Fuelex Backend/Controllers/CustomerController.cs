using Fuelex_Backend.Models.Customer;
using Fuelex_Backend.Models.CustomerModel;
using Fuelex_Backend.Models.LoginModel;
using Fuelex_Backend.Services.CustomerServices;
using Microsoft.AspNetCore.Mvc;
using System.Drawing;

namespace Fuelex_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService customerService;

        //Constructor
        public CustomerController(ICustomerService customerService)
        {
            this.customerService = customerService;
        }

        //POST api for login
        [HttpPost]
        public ActionResult<CustomerModel> CustomerLogin([FromBody]Login login)
        {
            var existingUsername = customerService.FindCusomter(login);

            if (existingUsername == null) {
                return NotFound($"User name {login.Username} not found");
            }

            //match the passwords
            if (existingUsername.Password == login.Password)
            {
                return Ok(existingUsername);
            }
            else
            {
                return BadRequest($"User is not authenticated");
            }
        }

        //GET api to get customer
        [HttpGet("{id}")]
        public ActionResult<CustomerModel> Get(string id)
        {
            var customer = customerService.Get(id);

            if (customer == null)
            {
                return NotFound($"Student with Id = {id} not found");
            }

            return customer;
        }

        //POST api for signup
        [HttpPost("/signup")]
        public ActionResult<CustomerModel> Post([FromBody] CustomerModel customerModel)
        {
            customerService.CreateCustomer(customerModel);
            return CreatedAtAction(nameof(Get), new {id = customerModel.Id}, customerModel);
        }
    }
}
