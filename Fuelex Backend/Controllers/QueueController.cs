using Fuelex_Backend.Models.CountModel;
using Fuelex_Backend.Models.FuelTypeModel;
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

        //Constructor
        public QueueController(IQueueService queueService)
        {
            this.queueService = queueService;
        }

        //GET api to get the queue count
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

        //PUT api to update the queue count
        [HttpPut("{location}/{vehicleType}/{fuelType}")]
        public ActionResult UpdateCounts(string location, string vehicleType, string fuelType, [FromBody] CountModel countModel)
        {
            var exisitngQueue = queueService.GetAllCounts(location, vehicleType, fuelType);

            if (exisitngQueue == null)
            {
                return NotFound($"Requested queue at {location} for vehicle type {vehicleType} with the fuel type of {fuelType} cannot be found");
            }

            //set the queue model
            QueueModel updateQueue = new QueueModel();
            updateQueue.Id = exisitngQueue.Id;
            updateQueue.Location = exisitngQueue.Location;
            updateQueue.VehicleType = exisitngQueue.VehicleType;
            updateQueue.FuelType = exisitngQueue.FuelType;

            //check the status
            if (countModel.Status == "Arrival")
            {
                updateQueue.CurrentCount = exisitngQueue.CurrentCount + 1;
                updateQueue.BeforeCount = exisitngQueue.BeforeCount;
                updateQueue.AfterCount = exisitngQueue.AfterCount;
                queueService.UpdateCount(location, vehicleType, fuelType, updateQueue);
                return Ok($"Updated the current count");
            }
            else if (countModel.Status == "BeforeLeave")
            {
                updateQueue.CurrentCount = exisitngQueue.CurrentCount - 1;
                updateQueue.BeforeCount = exisitngQueue.BeforeCount + 1;
                updateQueue.AfterCount = exisitngQueue.AfterCount;
                queueService.UpdateCount(location, vehicleType, fuelType, updateQueue);
                return Ok($"Updated before leave and current count");
            }
            else if (countModel.Status == "AfterLeave")
            {
                updateQueue.CurrentCount = exisitngQueue.CurrentCount - 1;
                updateQueue.BeforeCount = exisitngQueue.BeforeCount;
                updateQueue.AfterCount = exisitngQueue.AfterCount + 1;
                queueService.UpdateCount(location, vehicleType, fuelType, updateQueue);
                return Ok($"Updated before leave and current count");
            }
            else
            {
                return BadRequest($"Invalid count type");
            }
        }
    }
}
