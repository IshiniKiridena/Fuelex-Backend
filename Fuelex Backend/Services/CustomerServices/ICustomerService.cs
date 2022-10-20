using Fuelex_Backend.Models.CustomerModel;
using Fuelex_Backend.Models.LoginModel;

namespace Fuelex_Backend.Services.CustomerServices
{
    public interface ICustomerService
    {
        CustomerModel FindCusomter(Login login);

        CustomerModel CreateCustomer(CustomerModel customer);

        CustomerModel Get(string id);
    }
}
