using Fuelex_Backend.Models.FuelStationModel;
using Fuelex_Backend.Models.LoginModel;

namespace Fuelex_Backend.Services.FuelStation
{
    public interface IFuelStationService
    {
        FuelStationModel OwnerLogin(Login login);

        List <FuelStationModel> GetFuelStation();
    }
}
