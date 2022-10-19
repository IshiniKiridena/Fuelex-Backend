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
    }
}
