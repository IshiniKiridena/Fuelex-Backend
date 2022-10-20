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

        //GET api/<Customer controller>/username
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
    }
}
