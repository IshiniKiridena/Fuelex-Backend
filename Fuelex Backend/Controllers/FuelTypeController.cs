using Fuelex_Backend.Models.FuelTypeModel;
using Fuelex_Backend.Services.FuelType;
using Microsoft.AspNetCore.Mvc;

namespace Fuelex_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuelTypeController : ControllerBase
    {
        private readonly IFuelTypeService fuelTypeService;

        public FuelTypeController(IFuelTypeService fuelTypeService)
        {
            this.fuelTypeService = fuelTypeService;
        }

        [HttpGet("{location}")]
        public ActionResult<List<FuelTypeModel>> GetFuelType(string location)
        {
            var fueltype = fuelTypeService.GetFuelType(location);

            if(fueltype == null)
            {
                return NotFound();
            }

            return fueltype;
        }

        [HttpPut("{type}/{location}")]
        public ActionResult Put(string type, string location, [FromBody] FuelTypeModel fuelTypeModel)
        {
            var existingfueltype = fuelTypeService.Get(type, location);

            if (existingfueltype == null)
            {
                return NotFound($"fuelTypeModel with type = {type} not found");
            }
            fuelTypeService.UpdateFuel(type, location, fuelTypeModel);
            return NoContent();
        }

    }
}
