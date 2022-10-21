using Fuelex_Backend.Models.QueueModel;
using Fuelex_Backend.Services.Queue;
using Microsoft.AspNetCore.Mvc;

namespace Fuelex_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QueueController : ControllerBase
    {
        private readonly IQueueService queueService;

        public QueueController(IQueueService queueService)
        {
            this.queueService = queueService;
        }

        [HttpGet("{location}/{vehicleType}/{fuelType}")]
        public ActionResult<QueueModel> GetCounts(string location, string vehicleType, string fuelType)
        {
            var exisitingQueue = queueService.GetAllCounts(location, vehicleType, fuelType);

            if (exisitingQueue == null)
            {
                return NotFound($"Requested queue at {location} for vehicle type {vehicleType} with the fuel type of {fuelType} cannot be found");
            }

            return exisitingQueue;
        }
    }
}
