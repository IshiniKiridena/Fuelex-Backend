using Fuelex_Backend.Models.FuelStationModel;
using Fuelex_Backend.Models.LoginModel;
using Fuelex_Backend.Services.FuelStation;
using Fuelex_Backend.Services.FuelType;
using Microsoft.AspNetCore.Mvc;

namespace Fuelex_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuelStationController : ControllerBase
    {
        private readonly IFuelStationService fuelStationService;

        //Constructor
        public FuelStationController(IFuelStationService fuelStationService)
        {
            this.fuelStationService = fuelStationService;
        }

        //POST api for owner login
        [HttpPost]
        public ActionResult<FuelStationModel> OwnerLogin([FromBody]Login login)
        {
            var exisitngOwner = fuelStationService.OwnerLogin(login);

            if (exisitngOwner == null)
            {
                return NotFound($"Owner {login.Username} not found");
            }
            
            //match the passwords
            if (exisitngOwner.Password == login.Password)
            {
                return Ok(exisitngOwner);
            }
            else
            {
                return BadRequest($"User is not authenticated");
            }
        }

        //GET api to get all fuel stations
        [HttpGet]
        public ActionResult <List<FuelStationModel>> GetFuelStation()
        {
            return fuelStationService.GetFuelStation();
        }
    }
}
