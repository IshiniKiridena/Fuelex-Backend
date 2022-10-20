using Fuelex_Backend.Models.CustomerModel;
using Fuelex_Backend.Models.FuelStationModel;
using Fuelex_Backend.Models.LoginModel;
using MongoDB.Driver;

namespace Fuelex_Backend.Services.FuelStation
{
    public class FuelStationService : IFuelStationService
    {
        private readonly IMongoCollection<FuelStationModel> _fuelStationModel;
            
        public FuelStationService(IFuelStationDBSettings settings, IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase(settings.DatabaseName);
            _fuelStationModel = database.GetCollection<FuelStationModel>(settings.FuelStationCollectionName);
        }

        public FuelStationModel OwnerLogin(Login login)
        {
            return _fuelStationModel.Find(owner => owner.UserName == login.Username).FirstOrDefault();
        }
    }
}
