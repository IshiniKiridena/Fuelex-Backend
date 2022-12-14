using Fuelex_Backend.Models.FuelTypeModel;

namespace Fuelex_Backend.Services.FuelType
{
    public interface IFuelTypeService
    {
        FuelTypeModel Get(string type, string location);

        List<FuelTypeModel> GetFuelType(string location);

        FuelTypeModel GetFuel(string location, string type);

        void UpdateFuel(string type, string location, FuelTypeModel fuelTypeModel);

    }
}
