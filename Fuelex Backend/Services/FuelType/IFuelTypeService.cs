using Fuelex_Backend.Models.FuelTypeModel;

namespace Fuelex_Backend.Services.FuelType
{
    public interface IFuelTypeService
    {
        FuelTypeModel Get(string id);

        List<FuelTypeModel> GetFuelType();

        void UpdateFuelArrivalTime(string id,FuelTypeModel fuelTypeModel);

        void UpdateFuelFinishTime(string id, FuelTypeModel fuelTypeModel);

        void UpdateFuelStatus(string id, FuelTypeModel fuelTypeModel);
    }
}
