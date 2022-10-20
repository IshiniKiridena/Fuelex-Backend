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

        [HttpGet]
        public ActionResult<List<FuelTypeModel>> GetFuelType()
        {
            return fuelTypeService.GetFuelType();
        }

        [HttpPut("{id}")]
        public ActionResult Put(string id, [FromBody] FuelTypeModel fuelTypeModel)
        {
            var existingfueltype = fuelTypeService.Get(id);

            if (existingfueltype == null)
            {
                return NotFound($"fuelTypeModel with id = {id} not found");
            }
            fuelTypeService.UpdateFuelArrivalTime(id, fuelTypeModel);
            return NoContent();
        }

        [HttpPut("/finish/{id}")]
        public ActionResult Putf(string id, [FromBody] FuelTypeModel fuelTypeModel)
        {
            var existingfueltype = fuelTypeService.Get(id);

            if (existingfueltype == null)
            {
                return NotFound($"fuelTypeModel with id = {id} not found");
            }
            fuelTypeService.UpdateFuelFinishTime(id, fuelTypeModel);
            return NoContent();
        }

        [HttpPut("/status/{id}")]
        public ActionResult Puts(string id, [FromBody] FuelTypeModel fuelTypeModel)
        {
            var existingfueltype = fuelTypeService.Get(id);

            if (existingfueltype == null)
            {
                return NotFound($"fuelTypeModel with id = {id} not found");
            }
            fuelTypeService.UpdateFuelStatus(id, fuelTypeModel);
            return NoContent();
        }
    }
}
