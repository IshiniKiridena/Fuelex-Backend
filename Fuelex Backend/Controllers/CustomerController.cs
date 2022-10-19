using Fuelex_Backend.Services.Customer;
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
    }
}
