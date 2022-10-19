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

        public FuelStationController(IFuelStationService fuelStationService)
        {
            this.fuelStationService = fuelStationService;
        }
    }
}
