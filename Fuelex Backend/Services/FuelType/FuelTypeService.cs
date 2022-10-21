using MongoDB.Driver;
using Fuelex_Backend.Models.FuelTypeModel;

namespace Fuelex_Backend.Services.FuelType
{
    public class FuelTypeService : IFuelTypeService
    {

        private readonly IMongoCollection<FuelTypeModel> _fuelTypeModel;

        public FuelTypeService(IFuelTypeDBSetttings settings, IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase(settings.DatabaseName);
            _fuelTypeModel = database.GetCollection<FuelTypeModel>(settings.FuelTypeCollectionName);
        }


        public FuelTypeModel Get(string type, string location)
        {
            return _fuelTypeModel.Find(fuelType => fuelType.Type == type && fuelType.Location == location).FirstOrDefault();
        }

        public List<FuelTypeModel> GetFuelType(string location)
        {
            return _fuelTypeModel.Find(fuelTypeModel=> fuelTypeModel.Location == location).ToList();
        }

        public void UpdateFuel(string type, string location, FuelTypeModel fuelTypeModel)
        {
            _fuelTypeModel.ReplaceOne(fuelTypeModel => fuelTypeModel.Location == location && fuelTypeModel.Type == type, fuelTypeModel);
        }

    }
}
