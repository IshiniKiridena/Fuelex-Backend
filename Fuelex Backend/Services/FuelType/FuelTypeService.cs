using MongoDB.Driver;
using Fuelex_Backend.Models.FuelTypeModel;

namespace Fuelex_Backend.Services.FuelType
{
    public class FuelTypeService : IFuelTypeService
    {

        private readonly IMongoCollection<FuelTypeModel> _fuelTypeModel;

        public FuelTypeModel Get(string id)
        {
            return _fuelTypeModel.Find(fuelTypeModel => fuelTypeModel.Id == id).FirstOrDefault();
        }

        public FuelTypeService(IFuelTypeDBSetttings settings, IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase(settings.DatabaseName);
            _fuelTypeModel = database.GetCollection<FuelTypeModel>(settings.FuelTypeCollectionName);
        }

        public List<FuelTypeModel> GetFuelType()
        {
            return _fuelTypeModel.Find(fuelTypeModel=>true).ToList();
        }

        public void UpdateFuelArrivalTime(string id, FuelTypeModel fuelTypeModel)
        {
            _fuelTypeModel.ReplaceOne(fuelTypeModel => fuelTypeModel.Id == id, fuelTypeModel);
        }

        public void UpdateFuelFinishTime(string id, FuelTypeModel fuelTypeModel)
        {
            _fuelTypeModel.ReplaceOne(fuelTypeModel => fuelTypeModel.Id == id, fuelTypeModel);
        }

        public void UpdateFuelStatus(string id, FuelTypeModel fuelTypeModel)
        {
            _fuelTypeModel.ReplaceOne(fuelTypeModel => fuelTypeModel.Id == id, fuelTypeModel);
        }
    }
}
