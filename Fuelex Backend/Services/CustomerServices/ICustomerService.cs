using Fuelex_Backend.Models.CustomerModel;
using Fuelex_Backend.Models.LoginModel;

namespace Fuelex_Backend.Services.CustomerServices
{
    public interface ICustomerService
    {
        CustomerModel FindCusomter(Login login);
    }
}
