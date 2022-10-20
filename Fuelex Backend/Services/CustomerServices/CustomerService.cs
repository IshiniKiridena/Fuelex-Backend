using Fuelex_Backend.Models.Customer;
using Fuelex_Backend.Models.CustomerModel;
using Fuelex_Backend.Models.LoginModel;
using Fuelex_Backend.Services.CustomerServices;
using MongoDB.Driver;

namespace Fuelex_Backend.Services.Customer
{
    public class CustomerService : ICustomerService
    {
        private readonly IMongoCollection<CustomerModel> _customerModel;

        public CustomerService(ICustomerDBSettings settings, IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase(settings.DatabaseName);
            _customerModel = database.GetCollection<CustomerModel>(settings.CustomerCollectionName);
        }

        public CustomerModel FindCusomter(Login login)
        {
            return _customerModel.Find(customer => customer.UserName == login.Username).FirstOrDefault();
        }
    }
}
