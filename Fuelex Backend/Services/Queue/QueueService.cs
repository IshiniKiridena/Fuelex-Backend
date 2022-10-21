using Fuelex_Backend.Models.QueueModel;
using MongoDB.Driver;

namespace Fuelex_Backend.Services.Queue
{
    public class QueueService : IQueueService
    {
        private readonly IMongoCollection<QueueModel> _queueModel;

        public QueueService(IQueueDBSettings settings, IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase(settings.DatabaseName);
            _queueModel = database.GetCollection<QueueModel>(settings.QueueCollectionName);
        }

        public QueueModel GetAllCounts(string location, string vehicleType, string fuelType)
        {
            return _queueModel.Find(queue => queue.Location == location && queue.VehicleType == vehicleType && queue.FuelType == fuelType).FirstOrDefault();
        }

        public void UpdateCount(string location, string vehicleType, string fuelType, QueueModel _queue)
        {
           _queueModel.ReplaceOne(queue => queue.Location == location && queue.VehicleType == vehicleType && queue.FuelType == fuelType, _queue);
        }

    }
}
