using Fuelex_Backend.Models.QueueModel;

namespace Fuelex_Backend.Services.Queue
{
    public interface IQueueService
    {
        QueueModel GetAllCounts(string location, string vehicleType, string fuelType);
    }
}
